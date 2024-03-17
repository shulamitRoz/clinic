using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTO;
using WebApi.Entities;

namespace WebApi.Core
{
    public  class Mapping
    {
        public DoctorDto MapToDoctorDto(Doctors doctor)
        {
            return  new DoctorDto { Id = doctor.Id, NameDoctor = doctor.NameDoctor, SpecializationDoctor = doctor.SpecializationDoctor };
        }

    }
}
