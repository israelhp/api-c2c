using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class OrderDetail
    {
        public int id { get; set; }
        public Order order { get; set; }
        public int LineNumber { get; set; }
        public Products product { get; set; }
        public string comment { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public double lineTotal { get; set; }


    }
}