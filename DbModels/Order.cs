using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Order
    {
        public int id { get; set; }
        public Users user { get; set; }
        public string currency { get; set; }
        public string nit { get; set; }
        public string name { get; set; }
        public string observations { get; set; }
        public DateTime date { get; set; }
        public Payment pago { get; set; }
    }
}