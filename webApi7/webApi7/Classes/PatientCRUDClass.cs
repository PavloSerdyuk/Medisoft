using System;
using System.Collections.Generic;
using webApi7.Models;

namespace webApi7
{
    public interface IPatient
    {
        IEnumerable<Patient> Get();
        Patient Get(int id);
        void Create(Patient p);
        void Update(Patient p);
       
    }
    public class PatientCRUD : IPatient
    {
        private kpz6Context Context;
        public IEnumerable<Patient> Get()
        {
            return Context.Patient;
        }

        public Patient Get(int Id)
        {
            return Context.Patient.Find(Id);
        }
        public PatientCRUD(kpz6Context context)
        {
            Context = context;
        }
        public void Create(Patient p)
        {
            Context.Patient.Add(p);
            Context.SaveChanges();
        }
        public void Update(Patient updated)
        {
            Patient current = Get(updated.Id);
            current.Id = updated.Id;
            current.FullName = updated.FullName;
            current.Address = updated.Address;
            current.Email = updated.Email;

            Context.Patient.Update(current);
            Context.SaveChanges();
        }

    }
}
