using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Core.ServiesModeld;
using WebApi.Entities;

namespace WebApi.Servies.ServiesRepository
{
    public class PatientServies : IPatientServies
    {
        private readonly IPatient _patien;

        public PatientServies(IPatient patient)
        {
            _patien = patient;
        }

        public IEnumerable<Patients> GetListPatients()
        {
            return _patien.GetAllPatient();
        }
        public async Task<Patients> GetPatientByIdAsync(int id)
        {
            return await _patien.GetPatientByIdAsync(id);

        }
        public void AddPatientAsync(Patients patients)
        {
            _patien.AddPatientAsync(patients);
        }
        public async Task<Patients> UpdatePatientAsync(int id, Patients patients)
        {
            if (id != -1)
            {
                return await _patien.UpdatePatientAsync(id, patients);
            }
            else return null;

        }
        public void DeletePatientAsync(int id)
        {
            int index = _patien.GetAllPatient().ToList().FindIndex((Patients e) => e.Id == id);

            if (index != -1)
            {
                _patien.DeletePatientAsync(index);

            }
        }

    }
}
