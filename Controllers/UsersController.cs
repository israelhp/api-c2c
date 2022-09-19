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
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("api/Users")]
        public HttpResponseMessage Post(Users value)
        {
            try
            {
                value.password = BCrypt.Net.BCrypt.HashPassword(value.password);
                UsersData.add(value);
                return Request.CreateResponse(HttpStatusCode.OK, new Utilities.FormatResponse(new { username= value.username, email = value.email , role = value.RolesId }, "Usuario se registro correctamente, ya puedes iniciar sesion!", null));
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Verifica que estos campos (username, email, dpi), debido a que existe un usuario con dicha informacion", e));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Utilities.FormatResponse(null, "Ocurrio un error intenta de nuevo mas tarde", e));
            }
        }
    }
}
