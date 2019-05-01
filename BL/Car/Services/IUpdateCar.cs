using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Car.DTO;

namespace BL.Car.Services
{
    public interface IUpdateCar
    {
         void Execute(CarDTO carDto);
    }
}
