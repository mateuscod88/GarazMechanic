using BL.Brand.DTO;
using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Brand.Service
{
    public class BrandService : IBrandService
    {
        private IDatabaseService _context;
        public  BrandService(IDatabaseService context)
        {
            _context = context;

        }
        public List<BrandDTO> GetAllBrands()
        {
            using (_context)
            {
                var brands = _context.Brands.Select(x => new BrandDTO
                {
                    ID = x.BrandID,
                    Name = x.Name
                }).ToList();
                return brands;
            }
            
        }
        public BrandDTO GetBrandById(int brandID)
        {
            using (_context)
            {
                return _context.Brands.Where(x => x.BrandID == brandID).Select(x => new BrandDTO
                {
                    ID = x.BrandID,
                    Name = x.Name
                }).FirstOrDefault();
            }
        }
            
        
    }
}
