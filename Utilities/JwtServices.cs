using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using api_c2c.DbModels;
using api_c2c.Data;


namespace api_c2c.Utilities
{
    public class JwtServices
    {
        public static string GenerateSecurityToken(string email)
        {
            byte[] signingKey = new byte[32];
            string myexpDate = ConfigurationManager.AppSettings["expiration"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, email)

                }),
                Expires = DateTime.UtcNow.AddYears(Int32.Parse(myexpDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static bool ValidateSecurityToken(string token)
        {
            byte[] signingKey = new byte[32];

            TokenValidationResult result = new JsonWebTokenHandler().ValidateToken(token,
               new TokenValidationParameters
               {
                   ValidateAudience = false,
                   ValidateIssuer = false,
                   ValidateLifetime = false,
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(signingKey)
               }
            );

            return result.IsValid;
        }

        public static bool isAuthenticated(string token){
            try
            {
                if (!ValidateSecurityToken(token)) return false;

                Users user = UsersData.UserByToken(token);

                if (user == null) return false;

                return true;
            }
            catch (Exception e )
            {
                return false;
            }
        }


    }
}