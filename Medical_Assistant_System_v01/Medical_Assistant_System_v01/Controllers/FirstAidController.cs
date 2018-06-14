using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v01.Controllers
{
    public class FirstAidController : ApiController
    {
        [HttpGet]
        [Route("api/FirstAid/get")]
        public HttpResponseMessage GetfirstAid(int id/*disease id*/) { 

            try {
                using(Medical_Assistant_System_Entities entities  = new Medical_Assistant_System_Entities()) {

                    var entity = entities.First_Aid.Where(f => f.Id_Diseases == id).ToList();
                    if (entity != null) {
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Disease with id: " + id + "not found");
                    }
                }
            }
            catch(Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}
