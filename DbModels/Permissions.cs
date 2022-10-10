using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Permissions
    {
        public int id {get;set;}
        public int endpoint {get;set;}

        [ForeignKey("Standard")]
        public int RolesId { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
