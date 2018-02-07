using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain
{
    public class Part
    {
        public int PartID { get; set; }
        public string Name { get; set; }
        public ICollection<Repair> Repairs { get; set; }
    }
}
