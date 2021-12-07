using System;
using System.Collections.Generic;
using webApi7.Models;

namespace webApi7
{
    public interface IDoctor
    {
        IEnumerable<Doctor> Get();
        Doctor Get(int id);
        void Create(Doctor d);
        void Update(Doctor d);
       
    }
    public class DoctorCRUD : IDoctor
    {
        private kpz6Context Context;
        public IEnumerable<Doctor> Get()
        {
            return Context.Doctor;
        }
        public Doctor Get(int Id)
        {
            return Context.Doctor.Find(Id);
        }
        public DoctorCRUD(kpz6Context context)
        {
            Context = context;
        }
        public void Create(Doctor p)
        {
            Context.Doctor.Add(p);
            Context.SaveChanges();
        }
        public void Update(Doctor updated)
        {
            Doctor current = Get(updated.Id);
            current.Id = updated.Id;
            current.FullName = updated.FullName;
            current.Specialization = updated.Specialization;
            current.Experience = updated.Experience;

            Context.Doctor.Update(current);
            Context.SaveChanges();
        }

    }
}
