using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Web;

namespace api_c2c.DbModels
{
    public class OrderDetail
    {
        public int id { get; set; }      
        public int LineNumber { get; set; }
        public string comment { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public double lineTotal { get; set; }



        [ForeignKey("Standard")]
        public int orderId { get; set; }
        [JsonIgnore]
        public virtual Order order { get; set; }

        [ForeignKey("Standard")]
        public int productId { get; set; }
        public virtual Products product { get; set; }
    }
}