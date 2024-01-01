using BasicApiExample.Models;

namespace BasicApiExample.Repositories.Interfaces
{
    public interface IPatient : IDisposable
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatient(int id);
        int CreatePatient(Patient patient);
        int UpdatePatient(Patient patient);
        int DeletePatient(int id);
    }
}
