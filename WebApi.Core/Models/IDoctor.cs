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
        public void AddDoctorAsync(Doctors doctors);
        Task<Doctors> PutDoctorAsync(int index,string doctors);
        public void DeleteDoctorAsync(int index);


    }
}
