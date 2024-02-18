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
        public Patients GetPatientById(int id)
        {
            return _patien.GetPatientById(id);

        }
        public void PostPatient(Patients patients)
        {
            _patien.AddPatient(patients);
        }
        public Patients PutPatient(int id, Patients patients)
        {
            if (id != -1)
            {
                return _patien.UpdatePatient(id, patients);
            }
            else return null;

        }
        public void DeletePatient(int id)
        {
            int index = _patien.GetAllPatient().ToList().FindIndex((Patients e) => e.Id == id);

            if (index != -1)
            {
                _patien.DeletePatient(index);

            }
        }

    }
}
