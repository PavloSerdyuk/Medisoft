using System;
using System.Collections.Generic;

namespace DatabaseFirst
{
    public partial class ShiftShedule
    {
        public int Id { get; set; }
        public int ShiftNumber { get; set; }
        public DateTime Day { get; set; }
        public string? Wishes { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
    }
}
