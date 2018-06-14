using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v01.Controllers
{
    public class MedicineController : ApiController
    {
        [HttpGet]
        [Route("api/Medicine/MedicineForPrescription")]
        public HttpResponseMessage GetAllMedicineForPrescription(int id/*prescription id*/) {

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                var entity = entities.Medicines.Where(m => m.Id_Prescription == id).ToList();
                if (entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Prescription with id " + id + " does not have any medicine yet");
                }
            }
        }

        [HttpGet]
        [Route("api/Medicine/MedicineForPatient")]
        public HttpResponseMessage GetAllMedicineForPatient(int id /*patient id*/) {

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {
                var entity = entities.Prescriptions.Where(p => p.Id_Patient == id).ToList();
                if (entity != null) {
                    List<Medicine> medi = new List<Medicine>();
                    foreach (var e in entity) {
                        medi.AddRange(e.Medicines);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, medi);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "patient with id " + id + " does not have medicines ");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage PostMedicine(Medicine newMedicine) {

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {
                    entities.Medicines.Add(newMedicine);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newMedicine);
                    message.Headers.Location = new Uri(Request.RequestUri + newMedicine.Id_Medicine.ToString());
                    return message;
                }
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
