using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Domain;
using BL.Owner.DTO;

namespace BL.Owner.Service
{
    interface IOwnerService
    {
        List<OwnerDTO> GetAll();
        OwnerDTO GetById(int ownerId);
    }
}
