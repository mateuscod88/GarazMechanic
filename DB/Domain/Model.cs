using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain
{
    public class Model
    {
        public int ModelID { get; set; }
        public string Name { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
