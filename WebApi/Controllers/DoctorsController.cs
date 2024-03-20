using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Core;
using WebApi.Core.DTO;
using WebApi.Core.ServiesModeld;
using WebApi.Entities;
using WebApi.Models;
using WebApi.Servies.ServiesRepository;

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
        //private readonly Mapping _mapping;
        private readonly IMapper _mapper;
        public DoctorsController(IDoctorServies context, IMapper mapper)
        {
            _doctorServies = context;
           _mapper = mapper ;
        }
        [HttpGet]
        public ActionResult<Doctors> Get()
        {

            var list = _doctorServies.GetListDoctors();
            Console.WriteLine(list);
            var listDto = _mapper.Map<IEnumerable<DoctorDto>>(list);

            return Ok(listDto);

        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var doctor = _doctorServies.GetDoctors(id);
            //var doctorDto=_mapping.MapToDoctorDto(doctor);         
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return Ok(doctorDto);
 
        }
        [HttpPost]
        public void Post([FromBody] DoctorDto newEvent)
        {
            var DoctorToAdd = _mapper.Map<Doctors>(newEvent);

            _doctorServies.AddListDoctors(DoctorToAdd);
            //var doctorToAdd = new Doctors { NameDoctor = newEvent.NameDoctor, SpecializationDoctor = newEvent.SpecializationDoctor };
            //_doctorServies.AddListDoctors(doctorToAdd);

        }
        [HttpPut("{id}")]
        public Doctors Put(int id, [FromBody] DoctorDto updateEvent)
        {
            var doctorToUpdate = _mapper.Map<Doctors>(updateEvent);
            return _doctorServies.updateDoctor(id, doctorToUpdate.NameDoctor);
               
            //var putDoctor = new Doctors { SpecializationDoctor = updateEvent.SpecializationDoctor };
            //string ChangeDoctor = putDoctor.ToString();
            //return _doctorServies.updateDoctor(id, ChangeDoctor);

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {        
            _doctorServies.DeleteDoctor(id);

        }

    }

}
