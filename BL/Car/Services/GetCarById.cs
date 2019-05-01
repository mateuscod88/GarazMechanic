using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Car.DTO;
namespace BL.Car.Services
{
    public class GetCarById : IGetCarById
    {
        private DB.Interface.IDatabaseService _context;
        public GetCarById(DB.Interface.IDatabaseService context)
        {
            _context = context;
        }
        public CarDTO Execute(int id)
        {
            var car = _context.Cars.Where(x => x.CarID == id).Select(x => new CarDTO
            {
                Id = x.CarID,
                Name = x.Name,
                Year = x.ProductionYear != null ? x.ProductionYear.Year : "",
                PlateNumber = x.PlateNumber,
                Phone = x.Owner != null ? x.Owner.Phone : x.Phone,
                Brand = x.Brand != null ? x.Brand.Name : "",
                BrandId = x.Brand != null ? x.Brand.BrandID : 0,
                HorsePower = x.HorsePower,
                Engine = x.Engine.Name,
                EngineId = x.Engine != null ? x.Engine.EngineID : 0,
                KilometerCounter = x.KilometerCounter,
                TechnicalCheck = x.TechnicalCheck,
                OwnerName = x.Owner != null ? x.Owner.Name : "",
                OwnerId = x.Owner != null ? x.Owner.OwnerID : 0,
                Model = x.Model != null ? x.Model.Name : "",
                ModelId = x.Model != null ? x.Model.ModelID : 0,
                Repairs = x.Repairs.Select(y => new BL.Repair.DTO.RepairDTO { Id = y.RepairID, Name = y.Name, Date = (DateTime)y.DateRepair }).ToList()
            }).FirstOrDefault();
            return car;
        }
    }
}
