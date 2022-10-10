using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api_c2c.Data;
using api_c2c.DbModels;
using System.Web.Http.Cors;

namespace api_c2c.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaymentController : ApiController
    {
        [HttpGet]
        [Route("api/Payments")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(PaymentsData.PaymentsList(), "Solicitud exitosa!", null));
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
        [Route("api/Payments")]
        public HttpResponseMessage Post([FromBody] Payment value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(PaymentsData.Add(value), "Agregado exitoso!", null));
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
        [Route("api/Payments")]
        public HttpResponseMessage Put([FromBody] Payment value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(PaymentsData.Update(value), "Actualizacion exitosa!", null));
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
        [Route("api/Payments")]
        public HttpResponseMessage Delete([FromUri] int value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(PaymentsData.Delete(value), "Eliminacion exitosa!", null));
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

        //[HttpGet]
        //[Route("api/Payments")]
        //public HttpResponseMessage Paginador([FromUri] string field, int quantity, int page)
        //{
        //    try
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(OrdersData.OrdersListpage(field, quantity, page), "Solicitud exitosa!", null));
        //    }
        //    catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error interno, verifique en la red", e));
        //    }
        //    catch (Exception e)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Error de sintaxis interna, comuniquese con su proveedor", e));
        //    }
        //}

    }
}
