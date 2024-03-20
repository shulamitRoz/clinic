using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Entities;

namespace WebApi.Data.DataRepository
{
    public class DoctorRepository : IDoctor
    {
        private readonly DataContext _DoctorData;

        public DoctorRepository(DataContext doctorData)
        {
            _DoctorData = doctorData;
        }
        public IEnumerable<Doctors> GetAllDoctors()
        {
            return _DoctorData.doctors.Include(p => p.patients);
        }
        
        public Doctors GetDoctorById(int id)
        {
            return _DoctorData.doctors.ToList().Find(e => e.Id == id);
        }
        public void AddDoctor(Doctors doctors)
        {
           _DoctorData.doctors.Add(doctors);
            _DoctorData.SaveChanges();
        }
        public Doctors PutDoctor(int index,string doctors)
        {
            
            _DoctorData.doctors.ToList()[index].NameDoctor = doctors;
            return _DoctorData.doctors.ToList()[index];
            _DoctorData.SaveChanges();
           
        }
        public void DeleteDoctor(int index)
        {
            //_DoctorData.doctors.ToList().RemoveAt(index);
            _DoctorData.Remove(_DoctorData.doctors.ToList()[index]);
            _DoctorData.SaveChanges();
        }
    }
}
