using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Core.ServiesModeld
{
    public interface IPatientServies
    {
        public IEnumerable<Patients> GetListPatients();
        public Patients GetPatientById(int id);
        public void PostPatient(Patients patient);
        public Patients PutPatient(int id, Patients patients);
        public void DeletePatient(int id);  
    }
}
