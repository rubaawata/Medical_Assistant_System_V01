using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medical_Assistant_System_v01.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpGet]
        [Route("api/Doctor/doctorProfile")]
        public HttpResponseMessage GetDetails(int id/*doctor id*/) {

            using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                var entity = entities.Doctors.FirstOrDefault(d => d.Id_Doctor == id);
                if(entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id " + id + " Not Found");
                }
            }
        }

        [HttpGet]
        [Route("api/Doctor/searchByName")]
        public HttpResponseMessage SearchDoctorByName(string name) {
            
            using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                var entity = entities.Doctors.Where(d => (d.FirstName+d.LastName).ToLower().Contains(name.ToLower())).ToList();
                if(entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no Doctor with name " + name);
                }
            }
        }

        [HttpGet]
        [Route("api/Doctor/searchByCity")]
        public HttpResponseMessage SearchDoctorByCiy(string city) {

            using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                var entity = entities.Doctors.Where(d => d.Address.ToLower().Contains(city.ToLower())).ToList();
                if (entity != null) {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no Doctor in city " + city);
                }
            }
        }

        [HttpPut]
        public HttpResponseMessage PutDoctor(int id/*doctor id*/, Doctor newDoctor) {

            try {
                using (Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    var entity = entities.Doctors.FirstOrDefault(d => d.Id_Doctor == id);

                    if (entity != null) {
                        entity.Available_Appointment = newDoctor.Available_Appointment;
                        entity.Phone_Number = newDoctor.Phone_Number;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id =" + id.ToString() + " not found to update");
                    }
                }
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteDoctor(int id/*docotor id*/) {

            try {
                using(Medical_Assistant_System_Entities entities = new Medical_Assistant_System_Entities()) {

                    var entity = entities.Doctors.FirstOrDefault(d => d.Id_Doctor == id);
                    if(entity != null) {
                        entities.Doctors.Remove(entity);
                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Doctor with id " + id + " not found to delete");
                    }
                }
            }
            catch(Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
