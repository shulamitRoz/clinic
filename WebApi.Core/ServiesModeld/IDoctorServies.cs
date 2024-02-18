using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Core.ServiesModeld
{
    public interface IDoctorServies
    {
        public List<Doctors> GetListDoctors();
        public Doctors GetDoctors(int id);
        public void AddListDoctors(Doctors doctors);
        public Doctors updateDoctor(int id, string doctor);
        public void DeleteDoctor(int id);   
    }
}
