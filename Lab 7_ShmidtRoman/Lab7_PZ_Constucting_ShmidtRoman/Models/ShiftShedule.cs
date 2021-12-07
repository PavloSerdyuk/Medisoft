using System;
using System.Collections.Generic;

namespace Lab7_PZ_Constucting_ShmidtRoman
{
    public partial class ShiftShedule
    {
        public int Id { get; set; }
        public int ShiftNumber { get; set; }
        public DateTime Day { get; set; }
        public string? Wishes { get; set; }
        public int DoctorCodeId { get; set; }

        public virtual Doctor DoctorCode { get; set; } = null!;
    }
}
