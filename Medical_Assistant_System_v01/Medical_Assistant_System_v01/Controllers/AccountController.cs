using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v01.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("api/Account/details")]
        public HttpResponseMessage GetAccountDetails(int id /*account id*/) {

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                var entity = entities.Patient_Account.FirstOrDefault(ac => ac.Id_Account == id);
                if(entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Account with id " + id + " Not found");
                }
            }

        }
    }
}
