using api_c2c.DbModels;
using api_c2c.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http;
using System.Net;

namespace api_c2c.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CatalogController : ApiController
    {
        [HttpGet]
        [Route("api/Catalogs")]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(CatalogsData.CatalogsList(), "Solicitud exitosa!", null));
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
        [Route("api/Catalogs")]
        public HttpResponseMessage Post([FromBody] ItemFamily value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(CatalogsData.Add(value), "Agregado exitoso!", null));
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
        [Route("api/Catalogs")]
        public HttpResponseMessage Put([FromBody] ItemFamily value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(CatalogsData.Update(value), "Actualizacion exitosa!", null));
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
        [Route("api/Catalogs")]
        public HttpResponseMessage Delete([FromUri] int value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(CatalogsData.Delete(value), "Eliminacion exitosa!", null));
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
