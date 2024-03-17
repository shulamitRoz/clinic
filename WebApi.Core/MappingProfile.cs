using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTO;
using WebApi.Entities;

namespace WebApi.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctors,DoctorDto>().ReverseMap();
            CreateMap<Patients, PatientDto>().ReverseMap();
            CreateMap<Turn, TurnDto>().ReverseMap();
        }
    }
}
