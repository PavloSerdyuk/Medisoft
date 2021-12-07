using System.Collections.Generic;

namespace Hospital.Models{
    public class HospitalBuilding    {
        public int id {get; set;}
        public IList<Patient> patients {get; set;}

        public void addPatients(IList<Patient> patients)
        {
            this.patients = patients;
        }
        
    }
}