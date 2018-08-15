using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain
{
    public class Repair
    {
        public int RepairID { get; set; }
        public string Name { get; set; }
        public string IsInactive { get; set; }
        public DateTime RepairDate { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<RepairNotes> RepairNotes{ get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
