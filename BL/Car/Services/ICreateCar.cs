﻿using BL.Car.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Car.Services
{
    public interface ICreateCar
    {
         void Execute(CarDTO carDto);
    }
}
