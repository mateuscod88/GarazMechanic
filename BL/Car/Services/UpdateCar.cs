using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interface;
using BL.Car.DTO;
namespace BL.Car.Services
{
    public class UpdateCar : IUpdateCar
    {
        private IDatabaseService _context;
        public UpdateCar(IDatabaseService context)
        {
            _context = context;
        }
        public void Execute(CarDTO carDto)
        {
            using (_context)
            {
                var model = _context.Models.Where(x => x.Name == carDto.Model).FirstOrDefault();
                var brand = _context.Brands.Where(x => x.Name == carDto.Brand).FirstOrDefault();
                var owner = _context.Owners.Where(x => x.Name == carDto.OwnerName).FirstOrDefault();
                var productionYear = _context.ProductionYear.Where(x => x.Year == carDto.Year).FirstOrDefault();
                var engine = _context.Engines.FirstOrDefault(x => x.Brand.BrandID == carDto.BrandId && x.Model.ModelID == carDto.ModelId && x.Name == carDto.Engine);

                var updatedCar = _context.Cars.Where(x => x.CarID == carDto.Id).FirstOrDefault();
                updatedCar.Name = !string.IsNullOrEmpty(carDto.Name) ? carDto.Name : updatedCar.Name;
                updatedCar.Brand = brand != null ? brand : updatedCar.Brand;
                updatedCar.Model = model != null ? model : updatedCar.Model;
                updatedCar.ProductionYear = productionYear != null ? productionYear : updatedCar.ProductionYear;
                updatedCar.Owner = owner != null ? owner :updatedCar.Owner;
                updatedCar.HorsePower = !string.IsNullOrEmpty(carDto.HorsePower) ? carDto.HorsePower : updatedCar.HorsePower;
                updatedCar.PlateNumber = !string.IsNullOrEmpty(carDto.PlateNumber) ? carDto.PlateNumber : updatedCar.PlateNumber;
                updatedCar.KilometerCounter = updatedCar.KilometerCounter;
                updatedCar.Phone = !string.IsNullOrEmpty(carDto.Phone) ? carDto.Phone : updatedCar.Phone;
                updatedCar.TechnicalCheck = carDto.TechnicalCheck != null ? carDto.TechnicalCheck : updatedCar.TechnicalCheck;
                updatedCar.Engine = engine;
                _context.Save();

            }
        }
    }
}
