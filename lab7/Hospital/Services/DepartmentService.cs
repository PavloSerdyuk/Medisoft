using System.Collections.Generic;
using Hospital.Models;

namespace Hospital.Services {
    public class DepartmentService : IDepartmentService
{
	private readonly IList<Patient> patients;

	public DepartmentService()
	{
		            
	}

	public void AddPatient(Patient patient)
	{
		patients.Add(patient);
	}
    public IList<Patient> getPatients(){
        return patients;
    }        
}
}