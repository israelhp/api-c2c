using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Products
    {
        public int id {get;set;}
        public string name {get;set;}
        public double salePrice {get;set;}
        public bool available { get;set;}
        public string description { get; set; }
        public ItemFamily itemFamily { get; set; }
    }
}
