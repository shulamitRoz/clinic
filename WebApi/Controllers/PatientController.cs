using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApi.Core.ServiesModeld;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        //private static List<Patients> patients = new List<Patients> { 
        //new Patients{ PatienName="shulamit", PatientId=369,Status="Under the age of 18"},
        // new Patients{ PatienName="chani", PatientId=654,Status=  "Over the age of 40"},
        // new Patients{ PatienName="chaim", PatientId=321,Status=  "Over the age of 60"}

        //};
        private readonly IPatientServies _IPatientServies;

        public PatientController(IPatientServies context)
        {
            _IPatientServies = context;
        }
        [HttpGet]
        public IEnumerable<Patients> Get()
        {
            return _IPatientServies.GetListPatients();

        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_IPatientServies.GetPatientById(id));
            //var isIDExists = _IPatientServies.GetListPatients().Find(e => e.Id == id);
            //if (isIDExists == null)
            //    return NotFound();
            //else
            //    return Ok(isIDExists);
        }
        [HttpPost]
        public void Post([FromBody] Patients newEvent)
        {
            _IPatientServies.PostPatient(newEvent);
            //return _IPatientServies.GetListPatients()[_IPatientServies.GetListPatients().Count - 1];
        }
        [HttpPut("{id}")]
        public Patients Put(int id, [FromBody] Patients updateEvent)
        {

            return _IPatientServies.PutPatient(id, updateEvent);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _IPatientServies.DeletePatient(id);
        }


    }
}
