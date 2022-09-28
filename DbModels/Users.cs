using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string dpi { get; set; }
        public DateTime birth_date { get; set; }
        public string address { get; set; }
        public string nit { get; set; }
        public bool isVerification { get; set; }
        public string tokenResetPassword { get; set; }
        public string token { get; set; }

        [ForeignKey("Standard")]
        public int RolesId { get; set; }
        public virtual Roles Roles { get; set; }

    }
}
