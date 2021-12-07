using System;
using System.Collections.Generic;

namespace webApi7.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? DeclId { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
