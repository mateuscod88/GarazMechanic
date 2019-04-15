using BL.Brand.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Brand.Service
{
    public interface IBrandService
    {
        List<BrandDTO> GetAllBrands();
        BrandDTO GetBrandById(int brandID);
    }
}
