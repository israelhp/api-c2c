using api_c2c.DbModels;
using api_c2c.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api_c2c.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {

        [HttpGet]
        [Route("api/Products")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(ProductsData.ProductsList(), "Solicitud exitosa!", null));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error interno, verifique en la red", e));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Error de sintaxis interna, comuniquese con su proveedor", e));
            }
        }

        [HttpPost]
        [Route("api/Products")]
        public HttpResponseMessage Post([FromBody] Products value)
        {
            try
            {
                ProductsData.add(value);
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(value, "Usuario se registro correctamente, ya puedes iniciar sesion!", null));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Verifica que estos campos (username, email, dpi), debido a que existe un usuario con dicha informacion", e));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error intenta de nuevo mas tarde", e));
            }

        }

        [HttpPut]
        [Route("api/Products")]
        public HttpResponseMessage Put([FromBody] Products value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(ProductsData.Update(value), "Actualizado con exito!", null));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(false, "Ocurrio un error interno, verifique en la red", e));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(false, "Error de sintaxis interna, comuniquese con su proveedor", e));
            }
        }

        [HttpDelete]
        [Route("api/Products")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(ProductsData.delete(id), "Eliminado con exito!", null));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(false, "Ocurrio un error interno, verifique en la red", e));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(false, "Error de sintaxis interna, comuniquese con su proveedor", e));
            }
        }

        [HttpGet]
        [Route("api/Products/getbyid")]
        public HttpResponseMessage Get([FromUri] int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(ProductsData.ProductsList(id), "Solicitud exitosa!", null));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error interno, verifique en la red", e));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Error de sintaxis interna, comuniquese con su proveedor", e));
            }
        }

        [HttpGet]
        [Route("api/Products/getbyrange")]
        public HttpResponseMessage Get([FromUri] string field, int quantity, int page)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(ProductsData.ProductsListbyid(field, quantity, page), "Solicitud exitosa!", null));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error interno, verifique en la red", e));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Error de sintaxis interna, comuniquese con su proveedor", e));
            }           
        }

       
    }
}
