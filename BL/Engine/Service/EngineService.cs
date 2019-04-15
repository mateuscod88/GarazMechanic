using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Engine.Service
{
    public class EngineService : IEngineService
    {
        private IDatabaseService _context;
        public EngineService(IDatabaseService context)
        {
            _context = context;
        }
        public List<EngineDTO> GetAllByBrandAndModel(int brandId, int modelId)
        {
            var allEngines = _context.Engines.Where(x => x.Brand.BrandID == brandId && x.Model.ModelID == modelId)
                                             .Select(y => new EngineDTO {ID = y.EngineID , Name = y.Name })
                                             .ToList();
            return allEngines;
        }
    }
}
