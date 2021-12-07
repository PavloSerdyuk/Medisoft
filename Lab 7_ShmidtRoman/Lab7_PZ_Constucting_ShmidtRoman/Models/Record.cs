using System;
using System.Collections.Generic;

namespace Lab7_PZ_Constucting_ShmidtRoman
{
    public partial class Record
    {
        public Record()
        {
            WorkShedules = new HashSet<WorkShedule>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime Time { get; set; }
        public string Trouble { get; set; } = null!;

        public virtual ICollection<WorkShedule> WorkShedules { get; set; }
    }
}
