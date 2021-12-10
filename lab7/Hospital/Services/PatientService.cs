using Hospital.Models;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
    public static class PatientService
    {
        static List<Patient> Patients { get; }
        static int nextId = 3;
        static PatientService()
        {
            Patients = new List<Patient>
            {
                new Patient{firstName = "Anna", lastName = "Yablonska", dateOfBirth = "29/10/2001", id = 100000001, depId = 80000001},
                new Patient{firstName = "Lilia", lastName = "Marchenko", dateOfBirth = "27/11/1958", id = 100000005, depId = 80000001},
                new Patient{firstName = "Volodymyr", lastName = "Polishchuk", dateOfBirth = "10/05/1961", id = 100000003, depId = 80000002},
                new Patient{firstName = "Yurii", lastName = "Savchenko", dateOfBirth = "22/04/1967", id = 100000002, depId = 80000005},
                new Patient{firstName = "Nataliya", lastName = "Moroz", dateOfBirth = "20/05/1991", id = 100000007, depId = 80000003},
                new Patient{firstName = "Pavlo", lastName = "Lysenko", dateOfBirth = "10/02/2003", id = 100000006, depId = 80000006},
                new Patient{firstName = "Yaroslav", lastName = "Shevchenko", dateOfBirth = "23/06/1972", id = 100000004, depId = 80000002},
                new Patient{firstName = "Maryna", lastName = "Bondar", dateOfBirth = "12/07/1984", id = 100000010, depId = 80000005},
                new Patient{firstName = "Oleksandr", lastName = "Shevchuk", dateOfBirth = "11/03/2008", id = 100000009, depId = 80000007},
                new Patient{firstName = "Yana", lastName = "Oliynyk", dateOfBirth = "28/07/2000", id = 100000014, depId = 80000004},
                new Patient{firstName = "Nadiya", lastName = "Melnyk", dateOfBirth = "03/07/1990", id = 100000011, depId = 80000005},
                new Patient{firstName = "Anasatasiya", lastName = "Kravchenko", dateOfBirth = "12/12/1980", id = 100000012, depId = 80000004},
                new Patient{firstName = "Taras", lastName = "Boyko", dateOfBirth = "20/03/2010", id = 100000008, depId = 80000001},
                new Patient{firstName = "Oleksiy", lastName = "Rudenko", dateOfBirth = "28/03/2007", id = 100000014, depId = 80000001}
            };
        }

        public static List<Patient> GetAll() => Patients;

        public static Patient Get(int id) => Patients.FirstOrDefault(p => p.id == id);

        public static void Add(Patient patient)
        {
            patient.id = nextId++;
            Patients.Add(patient);
        }

        public static void Delete(int id)
        {
            var patient = Get(id);
            if(patient is null)
                return;

            Patients.Remove(patient);
        }

        public static void Update(Patient patient)
        {
            var index = Patients.FindIndex(p => p.id == patient.id);
            if(index == -1)
                return;

            Patients[index] = patient;
        }
    }
}