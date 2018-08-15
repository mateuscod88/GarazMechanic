using BL.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Model.Service
{
    interface IModelService
    {
        List<ModelDTO> GetAllModelsByBrandId(int brandId);
        ModelDTO GetModelById(int modelId);
    }
}
