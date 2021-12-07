using System;
using System.Collections.Generic;

namespace KpzLab6.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Experience { get; set; }
        public string Specialization { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
