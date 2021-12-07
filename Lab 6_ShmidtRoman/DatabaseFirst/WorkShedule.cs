using System;
using System.Collections.Generic;

namespace DatabaseFirst
{
    public partial class WorkShedule
    {
        public int Id { get; set; }
        public string? Wishes { get; set; }
        public DateTime Date { get; set; }
        public int DoctorsId { get; set; }
        public int RecordsId { get; set; }

        public virtual Doctor Doctors { get; set; } = null!;
        public virtual Record Records { get; set; } = null!;
    }
}
