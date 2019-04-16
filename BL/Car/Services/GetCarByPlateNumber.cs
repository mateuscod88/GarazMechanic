using BL.Car.DTO;
using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Car.Services
{
    public class GetCarByPlateNumber : IGetCarByPlateNumber
    {
        private IDatabaseService _context;
        public GetCarByPlateNumber(IDatabaseService context)
        {
            _context = context;
        }
        public CarDTO Execute(string plateNumber)
        {
            var car = _context.Cars.Where(x => x.PlateNumber == plateNumber).Select(x => new CarDTO
            {
                Id = x.CarID,
                Name = x.Name,
                Year = x.ProductionYear.Year,
                PlateNumber = x.PlateNumber,
                Phone = x.Owner.Phone,
                Brand = x.Brand.Name,
                BrandId = x.Brand.BrandID,
                HorsePower = x.HorsePower,
                OwnerName = x.Owner.Name,
                Model = x.Model.Name,
                ModelId = x.Model.ModelID,
                Repairs = x.Repairs.Select(y => new BL.Repair.DTO.RepairDTO { Id = y.RepairID, Name = y.Name, Date = (DateTime)y.DateRepair }).ToList()
            }).FirstOrDefault();
            return car;
        }
    }
}
