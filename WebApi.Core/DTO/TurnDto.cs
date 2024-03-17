using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Core.DTO
{
    public class TurnDto
    {
        public int Id { get; set; }
        public int TurnNumber { get; set; }

        public string Title { get; set; }

        public DateTime DateTurn { get; set; }

        public string TypeOfDoctor { get; set; }
        public int DoctorID { get; set; }
        public DoctorDto Doctor { get; set; }
        public PatientDto Patient { get; set; }
    }
}
