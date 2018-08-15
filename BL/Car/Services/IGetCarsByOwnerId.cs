using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Car.Services
{
    interface IGetCarsByOwnerId
    {
        List<BL.Car.DTO.CarDTO> Execute(int ownerId);
    }
}
