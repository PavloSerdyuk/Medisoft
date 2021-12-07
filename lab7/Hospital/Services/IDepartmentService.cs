using System.Collections.Generic;
using Hospital.Models;

namespace Hospital.Services{
    public interface IDepartmentService
    {
            void AddPatient(Patient patient);
            IList<Patient> getPatients();
    }
}