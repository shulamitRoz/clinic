using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string PatienName { get; set; }

        public string Status { get; set; }

    }
}
