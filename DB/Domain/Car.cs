using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain
{
    public class Car
    {
        public  int CarID { get; set; }
        public string Name{ get; set; }
        public string HorsePower { get; set; }
        public string PlateNumber { get; set; }
        public string Phone { get; set; }
        public DateTime? TechnicalCheck { get; set; }
        public virtual ProductionYear ProductionYear { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Model Model { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual ICollection<Repair> Repairs{ get; set; }

    }
}
