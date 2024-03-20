using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Core.ServiesModeld;
using WebApi.Entities;

namespace WebApi.Servies.serviesRepository
{
    public class DoctorServies: IDoctorServies
    {
        private readonly IDoctor _doctor;

        public DoctorServies(IDoctor doctor)
        {
            _doctor = doctor;
        }
        
        public List<Doctors> GetListDoctors()
        {
            return _doctor.GetAllDoctors().ToList();
        }

        public Doctors GetDoctors(int id)
        {
            return _doctor.GetDoctorById(id);
        }
        public void AddListDoctors(Doctors doctors)
        {
            _doctor.AddDoctor(doctors);
        }
        public Doctors updateDoctor(int id,string doctors)
        {
            int index = _doctor.GetAllDoctors().ToList().FindIndex((Doctors e) => e.Id == id );
            if(index != -1)
            {
               // string updateDoctor = _doctor.GetAllDoctors().ToList()[index].NameDoctor = doctors;
                _doctor.PutDoctor(index, doctors);
                return _doctor.GetAllDoctors().ToList()[index];
            }
            else return null;   

        }
        public void DeleteDoctor(int id)
        {

            int index = _doctor.GetAllDoctors().ToList().FindIndex((Doctors e) =>  e.Id == id);
            if (index != -1)
            {
                _doctor.DeleteDoctor(index);
            }    
        }
    }
}
