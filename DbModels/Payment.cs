using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Payment
    {
        public int id { get; set; }
        public string name { get; set; }
        public long card { get; set; }
        public int codCard { get; set; }
        public string securityCode { get; set; }
        public string expirationDate { get; set; }
        public double amount { get; set; }
        public double change { get; set; }
        public double cash { get; set; }
        public double paymentType { get; set; }
    }
}