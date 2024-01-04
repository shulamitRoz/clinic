using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private static List<Doctors> doctors = new List<Doctors>
        {
            new Doctors { NameDoctor ="avi", DoctorId=123,SpecializationDoctor="Pediatrician" },
            new Doctors { NameDoctor ="dani", DoctorId=456,SpecializationDoctor="family doctor" },
            new Doctors { NameDoctor ="shalom", DoctorId=78910,SpecializationDoctor="Ophthalmologist" },
        };
        [HttpGet]
        public IEnumerable<Doctors> Get()
        {
            return doctors;

        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var isIDExists = doctors.Find(e => e.DoctorId == id);
            if (isIDExists == null)
                return NotFound();
            else
                return Ok(isIDExists);
        }
        [HttpPost]
        public Doctors Post([FromBody] Doctors newEvent)
        {
            doctors.Add(new Doctors { DoctorId = 789, NameDoctor = newEvent.NameDoctor, SpecializationDoctor = newEvent.SpecializationDoctor });
         
            return doctors[doctors.Count - 1];
        }
        [HttpPut("{id}")]
        public Doctors Put(int id, [FromBody] Doctors updateEvent)
        {
            int index = doctors.FindIndex((Doctors e) => { return e.DoctorId == id; });
            doctors[index].DoctorId = updateEvent.DoctorId;
            doctors[index].NameDoctor = updateEvent.NameDoctor;
            doctors[index].SpecializationDoctor = updateEvent.SpecializationDoctor;
            return updateEvent;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var isIDExists = doctors.Find(e => e.DoctorId == id);
            if (isIDExists == null)
                return NotFound();
            else
                return Ok(isIDExists);
          
            int index = doctors.FindIndex((Doctors e) => { return e.DoctorId == id; });
            doctors.RemoveAt(index);
        }

    }
    
}
