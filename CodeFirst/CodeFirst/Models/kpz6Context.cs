using System;
using System.Data.Entity;

namespace CodeFirst.Models
{
    public partial class kpz6Context : DbContext
    {
        public kpz6Context() : base("name=DBConnection")
        {
        }

        

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Declaration> Declaration { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }

       

       
    }
}
