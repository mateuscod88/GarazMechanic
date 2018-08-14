using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain
{
    public class RepairNotes
    {
        public int RepairNotesID { get; set; }

        public string Description { get; set; }
        public virtual Repair Repair { get; set; }
    }
}
