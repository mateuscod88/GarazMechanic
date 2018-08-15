using BL.Model.DTO;
using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model.Service
{
    public class ModelService : IModelService
    {
        private IDatabaseService _context;
        public ModelService(IDatabaseService context)
        {
            _context = context;
        }
        public List<ModelDTO> GetAllModelsByBrandId(int brandId)
        {
            using (_context)
            {
               return _context.Models.Where(x => x.Brand.BrandID == brandId).Select(x => new ModelDTO
                {
                    ID = x.ModelID,
                    Name = x.Name,
                    BrandId = x.Brand.BrandID,
                    BrandName = x.Brand.Name
                }).ToList();
            }
        }
        public ModelDTO GetModelById(int modelId)
        {
            using (_context)
            {
                return _context.Models.Where(x => x.ModelID == modelId).Select(x => new ModelDTO
                {
                    ID = x.ModelID,
                    Name = x.Name,
                    BrandId = x.Brand.BrandID,
                    BrandName = x.Brand.Name
                }).FirstOrDefault();
            }
        }
    }
}
