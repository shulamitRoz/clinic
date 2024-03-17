using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApi.Core.DTO;
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
        private readonly IMapper _mapper;

        public PatientController(IPatientServies context,IMapper mapper)
        {
            _IPatientServies = context;
            _mapper = mapper;   
        }
        [HttpGet]
        public ActionResult<Patients> Get()

           
        {
            var list=_IPatientServies.GetListPatients();
            var PetientList=_mapper.Map<IEnumerable<PatientDto>>(list);
            return Ok(PetientList);

        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var patient= _IPatientServies.GetPatientById(id);   
            var newPatient=_mapper.Map<PatientDto>(patient);
            return Ok(newPatient);
      
        }
        [HttpPost]
        public void Post([FromBody] PatientDto newEvent)
        {
            var patientToAdd = _mapper.Map<Patients>(newEvent);
            _IPatientServies.PostPatient(patientToAdd);
            //return _IPatientServies.GetListPatients()[_IPatientServies.GetListPatients().Count - 1];
        }
        [HttpPut("{id}")]
        public Patients Put(int id, [FromBody] PatientDto updateEvent)
        {
            var patientToAdd = _mapper.Map<Patients>(updateEvent);

            return _IPatientServies.PutPatient(id, patientToAdd);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _IPatientServies.DeletePatient(id);
        }


    }
}
