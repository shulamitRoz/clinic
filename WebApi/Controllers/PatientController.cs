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
        public async Task<ActionResult> Get(int id)
        {
            var patient=await _IPatientServies. GetPatientByIdAsync(id);   
            var newPatient=_mapper.Map<PatientDto>(patient);
            return Ok(newPatient);
      
        }
        [HttpPost]
        public void Post([FromBody] PatientDto newEvent)
        {
            var patientToAdd = _mapper.Map<Patients>(newEvent);
            _IPatientServies.AddPatientAsync(patientToAdd);
           
        }
        [HttpPut("{id}")]
        public async Task<Patients> UpdatePatientAsync(int id, [FromBody] PatientDto updateEvent)
        {
            var patientToAdd = _mapper.Map<Patients>(updateEvent);

            return await _IPatientServies.UpdatePatientAsync(id, patientToAdd);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            _IPatientServies.DeletePatientAsync(id);
        }


    }
}
