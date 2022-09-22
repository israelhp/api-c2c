using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace api_c2c.DbModels
{
    public class Deliveries
    {
        public int id { get; set; }

        [ForeignKey("Standard")]
        public int orderId { get; set; }
        public Order order { get; set; }

        [ForeignKey("Standard")]
        public int statusId { get; set; }
        public Estados status { get; set; }

        [ForeignKey("Standard")]
        public int userId { get; set; }
        public Users user { get; set; }

    }
}