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
        public Owner Owner { get; set; }
        public Model Model { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Repair> Repairs{ get; set; }

    }
}
