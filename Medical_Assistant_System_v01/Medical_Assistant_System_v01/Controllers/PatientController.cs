using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v01.Controllers
{
    public class PatientController : ApiController
    {
        
        [HttpGet]
        [Route("api/Patient/patientProfile")]
        public HttpResponseMessage GetPatient(int id/*patient id*/){

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                var entity = entities.P_Personal_Infomation.FirstOrDefault(p => p.Id_Patient == id);
                if (entity != null){
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else{
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with id: " + id + "not found");
                }
            }
            
        }

        [HttpGet]
        [Route("api/Patient/Emergency")]
        public HttpResponseMessage GetEmergency(int id/*patient id*/) {
            using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                var entity = entities.Emergencies.Where(e => e.Id_Patient == id).ToList();
                if (entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "patient with id " + id + " Not found");
                }
            }

        }

        [HttpPost]
        public HttpResponseMessage PostPatient([FromBody] P_Personal_Infomation newPatient) {
             
            try{
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){
                    entities.P_Personal_Infomation.Add(newPatient);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newPatient);
                    message.Headers.Location = new Uri(Request.RequestUri + newPatient.Id_Patient.ToString());
                    return message;
                }
            }
            catch(Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage putProfile(int id/*patient id*/, P_Personal_Infomation patient){

            try{
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    var entity = entities.P_Personal_Infomation.FirstOrDefault(p => p.Id_Patient == id);

                    if (entity != null){
                        entity.Patient_Account = patient.Patient_Account;
                        entity.Patient_Allergy = patient.Patient_Allergy;
                        entity.Prescriptions = patient.Prescriptions;
                        entity.SocialStatus = patient.SocialStatus;
                        entity.Length_p = patient.Length_p;
                        entity.weight_p = patient.weight_p;
                        entity.Emergencies = patient.Emergencies;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else{
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with id =" + id.ToString() + " not found to update");
                    }
                }

            }
            catch (Exception ex){
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeletePateint(int id) {

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){

                    var entity = entities.P_Personal_Infomation.FirstOrDefault(p => p.Id_Patient == id);
                    if (entity != null) {
                        entities.P_Personal_Infomation.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with id = " + id + " not found to delete");
                    }
                }
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
