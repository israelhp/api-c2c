using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Order
    {
        public int id { get; set; }
        public string currency { get; set; }
        public string nit { get; set; }
        public string name { get; set; }
        public string observations { get; set; }
        public DateTime date { get; set; }
        public double total { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [ForeignKey("Standard")]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        // [ForeignKey("Standard")]
        // public int EstadoId { get; set; }
        // public Estados Estado { get; set; }

        [ForeignKey("Standard")]
        public int userId { get; set; }
        public Users user { get; set; }
    }
}