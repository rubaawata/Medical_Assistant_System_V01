using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v01.Controllers
{
    public class PrescriptionController : ApiController
    {

        [HttpGet]
        [Route("api/Prescription/details")]
        public HttpResponseMessage GetPrescription(int id/*presription id*/) {

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                var entity = entities.Prescriptions.FirstOrDefault(p => p.Id_Prescription == id);
                if(entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "prescription with id " + id + " Not Found");
                }
            }
        }

        [HttpGet]
        [Route("api/Prescription/healthyRecord")]
        public HttpResponseMessage GetHealthyRecordForPatient(int id/*patient id*/) {

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                var entity = entities.Prescriptions.Where(p => p.Id_Patient == id).ToList();
                if (entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "patient with id " + id + " Does not have record yet");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage PostPrescription(Prescription newPrescription) {

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {
                    entities.Prescriptions.Add(newPrescription);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newPrescription);
                    message.Headers.Location = new Uri(Request.RequestUri + newPrescription.Id_Prescription.ToString());
                    return message;
                }
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }


    }
}
