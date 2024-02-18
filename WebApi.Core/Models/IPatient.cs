using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Core.Models
{
    public interface IPatient
    {
        public IEnumerable<Patients> GetAllPatient();
        public Patients GetPatientById(int id);
        public void AddPatient(Patients patient);
        public Patients UpdatePatient(int id, Patients patients);
        public void DeletePatient(int id);  
    }
}
