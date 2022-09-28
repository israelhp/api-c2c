using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.Models.Request
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class ResetPassword
    {
        public string email { get; set; }
    }

    public class ValidateTokenResetPassword
    {
        public string email { get; set; }
        public string token { get; set; }
    }
}