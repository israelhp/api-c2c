using api_c2c.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_c2c.Utilities
{
    public class FormatResponse
    {
        public FormatResponse(dynamic value, string v, object p)
        {
            this.data = value;
            this.errorData = p;
            this.message = v;
        }

        public dynamic data { get; set; }
        public string message { get; set; }

        public dynamic errorData { get; set; }

    }
}