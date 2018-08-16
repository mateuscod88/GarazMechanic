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
                Year = x.ProductionYear.Year,
                PlateNumber = x.PlateNumber,
                Phone = x.Owner.Phone,
                Brand = x.Brand.Name,
                BrandId = x.Brand.BrandID,
                HorsePower = x.HorsePower,
                OwnerName = x.Owner.Name,
                Model = x.Model.Name,
                ModelId = x.Model.ModelID,
                Repairs = x.Repairs.Select(y => new BL.Repair.DTO.RepairDTO { Id = y.RepairID, Name = y.Name, Date = y.RepairDate }).ToList()
            }).FirstOrDefault();
            return car;
        }
    }
}
