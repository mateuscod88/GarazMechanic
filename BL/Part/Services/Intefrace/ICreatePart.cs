using BL.Part.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Part.Services.Intefrace
{
    public interface ICreatePart
    {
        void Execute(PartDTO partDto);
    }
}
