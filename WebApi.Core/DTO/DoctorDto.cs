using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string NameDoctor { get; set; }
        public string SpecializationDoctor { get; set; }
    }
}
