using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Engine.Service
{
    public interface IEngineService
    {
        List<EngineDTO> GetAllByBrandAndModel(int brandId, int modelId);
    }
}
