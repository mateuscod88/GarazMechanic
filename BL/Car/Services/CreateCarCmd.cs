﻿using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Car.DTO;

namespace BL.Car.Services
{
    public class CreateCarCmd : ICreateCar
    {
        private DB.Interface.IDatabaseService _context;
        public CreateCarCmd(DB.Interface.IDatabaseService context)
        {
            _context = context;
        }
        public void Execute(CarDTO carDto)
        {

            using (_context)
            {
                var model = _context.Models.Where(x => x.ModelID == carDto.ModelId).FirstOrDefault();
                var brand = _context.Brands.Where(x => x.BrandID== carDto.BrandId).FirstOrDefault();
                var owner = _context.Owners.Where(x => x.OwnerID == carDto.OwnerId).FirstOrDefault();
                var productionYear = _context.ProductionYear.Where(x => x.Year == carDto.Year).FirstOrDefault();
                var engine = _context.Engines.FirstOrDefault(x => x.Brand.BrandID == carDto.BrandId && x.Model.ModelID == carDto.ModelId && x.Name == carDto.Engine);

                DB.Domain.Car car = new DB.Domain.Car();
                car.Name = carDto.Name;
                car.Model = model;
                car.Owner = owner;
                car.Repairs = null;
                car.Brand = brand;
                car.Engine = engine;
                car.KilometerCounter = carDto.KilometerCounter;
                car.TechnicalCheck = carDto.TechnicalCheck;
                car.Phone = carDto.Phone;
                car.ProductionYear = productionYear;
                car.HorsePower = carDto.HorsePower;
                car.PlateNumber = carDto.PlateNumber;
                _context.Cars.Add(car);
                _context.Save();
            }
        }
    }
}
