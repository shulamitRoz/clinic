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
    public class PatientsRepository : IPatient
    {
        private readonly DataContext _PatientData;
        public PatientsRepository(DataContext patientData)
        {
            _PatientData = patientData;
        }
        public IEnumerable<Patients> GetAllPatient()
        {
            return _PatientData.patients;
        }
        public Patients GetPatientById(int id)
        {
            if (id != -1)
            {
                return _PatientData.patients.ToList().Find(e => e.Id == id);
            }
            else return null;
            _PatientData.SaveChanges();

        }
        public void AddPatient(Patients patient)
        {
            _PatientData.patients.Add(patient);
            _PatientData.SaveChanges();
        }
        public Patients UpdatePatient(int id, Patients patien)
        {
            int index = _PatientData.patients.ToList().FindIndex((Patients e) => e.Id == id);

            _PatientData.patients.ToList()[index].PatienName = patien.PatienName;
            _PatientData.patients.ToList()[index].Status = patien.Status;
            return _PatientData.patients.ToList()[index];
            _PatientData.SaveChanges();
        }
        public void DeletePatient(int index)
        {

            _PatientData.patients.Remove(_PatientData.patients.ToList()[index]);
            _PatientData.SaveChanges();
        }
    }
}
