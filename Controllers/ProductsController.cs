using api_c2c.DbModels;
using api_c2c.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_c2c.Controllers
{
    public class ProductsController : ApiController
    {

        //public IHttpActionResult Add([FromBody] OrdenFabricacion orden)
        //{

        //}

        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Products> Get()
        {         
            return ProductsData.ProductsList();
        }

        [HttpGet]
        [Route("api/Products/getbyid")]
        public Products Get([FromUri] int id)
        {
            return ProductsData.ProductsList(id);
        }

        [HttpGet]
        [Route("api/Products/getbyrange")]
        public IEnumerable<Products> Get([FromUri] string field, int quantity, int multiplier)
        {
            return ProductsData.ProductsListbyid(field,quantity, multiplier);
        }


        //probar esto con la respuesta http de OP 
        [HttpPost]
        [Route("api/Products")]
        public void Post([FromBody] Products value)
        {
            ProductsData.add(value);

        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody] Products value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
