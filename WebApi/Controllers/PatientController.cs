using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private static List<Patients> patients = new List<Patients> { 
        new Patients{ PatienName="shulamit", PatientId=369,Status="Under the age of 18"},
         new Patients{ PatienName="chani", PatientId=654,Status=  "Over the age of 40"},
         new Patients{ PatienName="chaim", PatientId=321,Status=  "Over the age of 60"}

        };
        [HttpGet]
        public IEnumerable<Patients> Get()
        {
            return patients;

        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var isIDExists = patients.Find(e => e.PatientId == id);
            if (isIDExists == null)
                return NotFound();
            else
                return Ok(isIDExists);
        }
        [HttpPost]
        public Patients Post([FromBody] Patients newEvent)
        {
            patients.Add(new Patients { PatientId = 789, PatienName = newEvent.PatienName, Status = newEvent.Status });

            return patients[patients.Count - 1];
        }
        [HttpPut("{id}")]
        public Patients Put(int id, [FromBody] Patients updateEvent)
        {
            int index = patients.FindIndex((Patients e) => { return e.PatientId == id; });
            patients[index].PatientId = updateEvent.PatientId;
            patients[index].PatienName = updateEvent.PatienName;
            patients[index].Status = updateEvent.Status;
            return updateEvent;
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            var isIDExists = patients.Find(e => e.PatientId == id);
            if (isIDExists == null)
                return NotFound();
            else
                return Ok(isIDExists);
            
            int index = patients.FindIndex((Patients e) => { return e.PatientId == id; });
            patients.RemoveAt(index);
        }
    }
}
