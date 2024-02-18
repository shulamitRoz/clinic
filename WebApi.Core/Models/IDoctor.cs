using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Core.Models
{
    public interface IDoctor
    {
        public IEnumerable<Doctors> GetAllDoctors();
        public Doctors GetDoctorById(int id);   
        public void AddDoctor(Doctors doctors);
        public void PutDoctor(int index,string doctors);
        public void DeleteDoctor(int index);


    }
}
