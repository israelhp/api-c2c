using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Deliveries
    {
        public int id { get; set; }
        public Order order { get; set; }
        public Estados status { get; set; }
        public Users user { get; set; }
    }
}