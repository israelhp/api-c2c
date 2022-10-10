using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{

    public class Roles
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}