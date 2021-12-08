using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.Models
{
    public class Footballer
    {
        [Key]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Column(TypeName = "nvarchar(2)")]
        public string ShirtNumber { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Position { get; set; }
    }
}
