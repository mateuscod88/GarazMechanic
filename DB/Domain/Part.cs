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
        public virtual PartBrand PartBrand { get; set; }
        public virtual PartCategory PartCategory { get; set; }
        public string Name { get; set; }
        public decimal PriceHurt { get; set; }
        public decimal PriceDetal { get; set; }
        public int Quantity { get; set; }

        public DateTime SupplyDate{ get; set; }


        public virtual ICollection<Repair> Repairs { get; set; }
    }
}
