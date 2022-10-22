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
    public class DeliveriesController : ApiController
    {


        [HttpGet]
        [Route("api/Deliveries")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(DeliveriesData.DeliveriesList(), "Solicitud exitosa!", null));
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
        [Route("api/DeliveriesDefaultOrders")]
        public HttpResponseMessage GetDeliveriesDefaultOrders([FromUri] int userId, int statusId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(DeliveriesData.DeliveriesDefault(userId, statusId), "Solicitud exitosa!", null));
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
        [Route("api/DeliveriesByOrderId")]
        public HttpResponseMessage GetByOrder([FromUri] int orderId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(DeliveriesData.OrderId(orderId), "Solicitud exitosa!", null));
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
        [Route("api/Deliveries")]
        public HttpResponseMessage Post([FromBody] Deliveries value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(DeliveriesData.Add(value), "Agregado exitoso!", null));
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
        [Route("api/Deliveries")]
        public HttpResponseMessage Put([FromBody] Deliveries value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(DeliveriesData.Update(value), "Actualizacion exitosa!", null));
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
        [Route("api/Deliveries")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(DeliveriesData.Delete(id), "Eliminacion exitosa!", null));
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
        [Route("api/Deliveries/page")]
        public HttpResponseMessage Filtrado([FromUri] string field, int quantity, int page)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(DeliveriesData.DeliveriesListFiltered(field, quantity, page), "Solicitud exitosa!", null));
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
