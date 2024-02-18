using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Core.ServiesModeld;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        //private static List<Doctors> doctors = new List<Doctors>
        //{
        //    new Doctors { NameDoctor ="avi", DoctorId=123,SpecializationDoctor="doctor of children" },
        //    new Doctors { NameDoctor ="dani", DoctorId=456,SpecializationDoctor="family doctor" },
        //    new Doctors { NameDoctor ="shalom", DoctorId=78910,SpecializationDoctor="Ophthalmologist" },
        //};

        private readonly IDoctorServies _doctorServies;

        public DoctorsController(IDoctorServies context)
        {
            _doctorServies = context;
        }
        [HttpGet]
        public IEnumerable<Doctors> Get()
        {
            return _doctorServies.GetListDoctors();

        }
        [HttpGet("{id}")]
        public Doctors Get(int id)
        {
            return _doctorServies.GetDoctors(id);        
            //var isIDExists = _doctorServies.GetListDoctors().Find(e => e.Id == id);
            //if (isIDExists == null)
            //    return NotFound();
            //else
            //    return Ok(isIDExists);
        }
        [HttpPost]
        public void Post([FromBody] Doctors newEvent)
        {
            _doctorServies.AddListDoctors(newEvent);
        }
        [HttpPut("{id}")]
        public Doctors Put(int id, [FromBody] string updateEvent)
        {
        
            return _doctorServies.updateDoctor(id, updateEvent);
             
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            //var isIDExists = _doctorServies.GetListDoctors().Find(e => e.DoctorId == id);
            //if (isIDExists == null)
            //    return NotFound();
            //else
            //    return Ok(isIDExists);
          
            //int index = _doctorServies.GetListDoctors().FindIndex((Doctors e) => { return e.DoctorId == id; });
            //_doctorServies.GetListDoctors().RemoveAt(index);
            _doctorServies.DeleteDoctor(id);

        }

    }
    
}
