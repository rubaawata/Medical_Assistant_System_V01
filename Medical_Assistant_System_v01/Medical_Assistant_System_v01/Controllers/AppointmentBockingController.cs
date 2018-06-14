using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v01.Controllers
{
    public class AppointmentBockingController : ApiController
    {
        [HttpGet]
        [Route("api/AppointmentBocking/patientAppointment")]
        public HttpResponseMessage GetAllAppointementForPatient(int id/*patient id*/) {

            List<Appointment_Bocking> av = null;
            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {
                //get list of prescription for the patient 
                var entity = entities.Prescriptions.Where(p => p.Id_Patient == id).ToList();
                if(entity != null){
                    av = new List<Appointment_Bocking>();
                    foreach(Prescription pi in entity){
                        //get the book appointement foreach prescription 
                        var e = entities.Appointment_Bocking.Where(ap => ap.Id_Prescription == pi.Id_Prescription).ToList();
                        if (e != null) {
                                av.AddRange(e);
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, av);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with id " + id + " does not have any appointments");
                }
            }
        }

        [HttpGet]
        [Route("api/AppointmentBocking/DoctorAppointment")]
        public HttpResponseMessage GetAllAppointementForDoctor(int id/*doctor id*/) {

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                List<Appointment_Bocking> av = null;
                var entity = entities.Available_Appointment.Where(ap => ap.Id_Doctor == id).ToList();
                if(entity != null) {

                    av = new List<Appointment_Bocking>();
                    foreach(Available_Appointment ap in entity) {
                        var e = entities.Appointment_Bocking.Where(apB => apB.Id_Available_Appointment == ap.Id_Available_Appointment).ToList();
                        if(e != null) {
                            av.AddRange(e);
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, av);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id " + id + " does not have any appointment");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage PostAppointementBooking([FromBody] Appointment_Bocking newAppointement) {
            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()){
                    entities.Appointment_Bocking.Add(newAppointement);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, newAppointement);
                    message.Headers.Location = new Uri(Request.RequestUri + newAppointement.Id_Appointment_Bocking.ToString());
                    return message;
                }
            }
            catch(Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAppointementBooking(int id) {

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    var entity = entities.Appointment_Bocking.FirstOrDefault(ap => ap.Id_Appointment_Bocking == id);
                    if (entity != null) {
                        entities.Appointment_Bocking.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Booking Appointement with id " + id + " Not Found to delete");
                    }
                }
            }
            catch(Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
