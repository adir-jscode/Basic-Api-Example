using BasicApiExample.Context;
using BasicApiExample.Models;
using BasicApiExample.Repositories.Interfaces;

namespace BasicApiExample.Repositories.Implementations
{
    public class PatientRepository : IPatient
    {
        private readonly ApplicationDbContext _dbcontext;
        public PatientRepository(ApplicationDbContext dbContext) 
        { 
            _dbcontext = dbContext;
        }
        public int CreatePatient(Patient patient)
        {
            var result = 1;
            if(patient != null) 
            { 
                _dbcontext.patients.Add(patient);
                _dbcontext.SaveChanges();
                result = patient.Id;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public int DeletePatient(int id)
        {
            var result = 1;
            var patient = _dbcontext.patients.Where(x => x.Id == id).FirstOrDefault();
            if(patient != null)
            {
                _dbcontext.patients.Remove(patient);
                _dbcontext.SaveChanges();
                result = patient.Id;
                
            }
            else
            {
                result = 0;
            }
            return result;
        }

        

        public IEnumerable<Patient> GetAllPatients()
        {
            var patient = _dbcontext.patients.ToList();
            return patient;
        }

        public Patient GetPatient(int id)
        {
            var patient = _dbcontext.patients.Where(p=>p.Id == id).FirstOrDefault();
            return patient;
        }

        public int UpdatePatient(Patient patient)
        {
            var result = 1;
            var patientId = _dbcontext.patients.Where(p=>p.Id != patient.Id).FirstOrDefault();
            if(patientId != null)
            {

                patientId.FirstName = patient.FirstName;
                patientId.LastName = patient.LastName;
                patientId.Age = patient.Age;
                patientId.Address = patient.Address;
                patientId.PatientType = patient.PatientType;
                patientId.Bedum = patient.Bedum;
                patientId.Diagnosis = patient.Diagnosis;
                
                _dbcontext.SaveChanges();
                 result = patient.Id;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public void Dispose()
        {
            _dbcontext?.Dispose();
        }
    }
}
