using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain
{
    public class Engine
    {
            public int EngineID { get; set; }
            public string Name { get; set; }
            public Brand Brand { get; set; }
            public Model Model { get; set; }
    }
}
