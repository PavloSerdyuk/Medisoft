using System;
using System.Collections.Generic;

namespace CodeFirst.Models
{
    public partial class Declaration
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        
    }
}
