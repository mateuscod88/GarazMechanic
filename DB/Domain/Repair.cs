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
        public DateTime RepairDate { get; set; }
        public Car Car { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}
