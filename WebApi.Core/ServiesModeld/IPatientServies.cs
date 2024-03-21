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
        public Task<Patients> GetPatientByIdAsync(int id);
        public void AddPatientAsync(Patients patient);
        public Task<Patients> UpdatePatientAsync(int id, Patients patients);
        public void DeletePatientAsync(int id);  
    }
}
