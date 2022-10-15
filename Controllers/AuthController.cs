using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_c2c.DbModels;
using api_c2c.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Web.Http.Cors;
using System.Net.Mail;

namespace api_c2c.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {

        [HttpPost]
        [Route("api/Auth")]
        public HttpResponseMessage Post(Models.Request.LoginRequest datalogin) 
        {
            Users user = UsersData.UserByEmail(datalogin.email);
            string token;

            if (BCrypt.Net.BCrypt.Verify(datalogin.password, user.password))
            {
                user.token = Utilities.JwtServices.GenerateSecurityToken(user.email);
                UsersData.UpdateUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, new Utilities.FormatResponse(new { username = user.username, token = user.token, role = user.RolesId, userId= user.id}, "Inicio sesion correctamente", null));
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "El correo / contraseña es invalido", null));
        }

        [HttpPost]
        [Route("api/Auth/Logout")]
        public HttpResponseMessage Logout()
        {
            try { 
                if (!Utilities.JwtServices.isAuthenticated(Request.Headers.Authorization.Parameter))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "No tienes acceso a esta pagina", null));

                Users user = UsersData.UserByToken(Request.Headers.Authorization.Parameter);
                user.token = null;
                if (!UsersData.UpdateUser(user))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error, intenta nuevamente", null));
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(null, "Se cerrar sesión correctamente", null));
            }
            catch(System.NullReferenceException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "No se pudo cerrar sesion correctamente", null));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "No se pudo cerrar sesion correctamente", null));
            }
            
        }

        [HttpPost]
        [Route("api/Auth/TokenResetPassword/Generate")]
        public HttpResponseMessage GenerateResetPassword(Models.Request.ResetPassword data)
        {
            try
            {
                Users user = UsersData.UserByEmail(data.email);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "No existe un usuario con ese correo", null));
                user.tokenResetPassword = Utilities.GeneratePassword.GenerateRandomPassword();
                Utilities.SendMail
                    .Send(user.email, 
                          "Cambio de Contraseña",
                          "Este es el token "+user.tokenResetPassword +" para poder realizar el cambio de contraseña. Saludos",
                          "Proyecto Seminario"
                          );
                UsersData.UpdateUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(data, "Se genero el token correctamente", null));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error, intenta nuevamente", e));
            }
        }

        [HttpPost]
        [Route("api/Auth/TokenResetPassword/Validate")]
        public HttpResponseMessage ValidateResetPassword(Models.Request.ValidateTokenResetPassword data)
        {
            try
            {
                Users user = UsersData.UserByEmail(data.email);
                if (user == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(new { isValidate = false }, "No existe un usuario con ese correo", null));
                if (user.tokenResetPassword != data.token)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(new { isValidate = false }, "El token ingresado no es el correcto", null));

                user.tokenResetPassword = null;
                UsersData.UpdateUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(new { isValidate = true} , "Se valido correctamente", null));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error, intenta nuevamente", e));
            }
        }

        [HttpPost]
        [Route("api/Auth/ResetPassword")]
        public HttpResponseMessage ResetPassword(Models.Request.LoginRequest data)
        {
            try
            {
                Users user = UsersData.UserByEmail(data.email);
                if(user == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "No existe un usuario con ese correo", null));

                user.password = BCrypt.Net.BCrypt.HashPassword(data.password);
                UsersData.UpdateUser(user);
                Utilities.SendMail
                    .Send(user.email,
                          "Se a cambiado tu contraseña",
                          "Tu contraseña actual es " + user.password+ ". Saludos",
                          "Proyecto Seminario"
                          );
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(data, "Se actualizo tu contraseña correctamente", null));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error, intenta nuevamente", e));
            }
        }
        
    }
}
