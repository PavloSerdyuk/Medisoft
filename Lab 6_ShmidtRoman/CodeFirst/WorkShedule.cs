using System;
using System.Collections.Generic;

namespace CodeFirst
{
    public partial class WorkShedule
    {
        public int Id { get; set; }
        public string? Wishes { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int RecordCodeId { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Record RecordCode { get; set; } = null!;
    }
}
