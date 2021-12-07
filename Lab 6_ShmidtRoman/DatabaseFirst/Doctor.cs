using System;
using System.Collections.Generic;

namespace DatabaseFirst
{
    public partial class Doctor
    {
        public Doctor()
        {
            ShiftShedules = new HashSet<ShiftShedule>();
            WorkShedules = new HashSet<WorkShedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Position { get; set; } = null!;

        public virtual ICollection<ShiftShedule> ShiftShedules { get; set; }
        public virtual ICollection<WorkShedule> WorkShedules { get; set; }
    }
}
