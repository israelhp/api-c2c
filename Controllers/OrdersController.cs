using api_c2c.Data;
using api_c2c.DbModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api_c2c.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {
        [HttpGet]
        [Route("api/Orders")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(OrdersData.OrdersList(), "Solicitud exitosa!", null));
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
        [Route("api/OrdersByUser")]
        public HttpResponseMessage GetByUSer([FromUri] int userId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(OrdersData.OrdersList(userId), "Solicitud exitosa!", null));
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
        [Route("api/Orders")]
        public HttpResponseMessage Post([FromBody] Order value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(OrdersData.Add(value), "Agregado exitoso!", null));
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

        [HttpPut]
        [Route("api/Orders")]
        public HttpResponseMessage Put([FromBody] Order value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(OrdersData.Update(value), "Actualizacion exitosa!", null));
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

        [HttpDelete]
        [Route("api/Orders")]
        public HttpResponseMessage Delete([FromUri] int value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(OrdersData.Delete(value), "Eliminacion exitosa!", null));
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
        [Route("api/Orders")]
        public HttpResponseMessage Paginador([FromUri] string field, int quantity, int page)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(OrdersData.OrdersListpage(field, quantity, page), "Solicitud exitosa!", null));
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
