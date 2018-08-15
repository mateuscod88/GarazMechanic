using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Car.Services
{
    public class GetCarsByOwnerId : IGetCarsByOwnerId
    {
        private IDatabaseService _context;
        public GetCarsByOwnerId(IDatabaseService context)
        {
            _context = context;
        }
        public List<BL.Car.DTO.CarDTO> Execute(int ownerId)
        {
            using (_context)
            {
                return _context.Cars.Where(x => x.Owner.OwnerID == ownerId).Select(x => new BL.Car.DTO.CarDTO
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
                    Repairs = x.Repairs.Select(y => new BL.Repair.DTO.RepairDTO { Id = y.RepairID,Name = y.Name,Date = y.RepairDate}).ToList()

                }).ToList();
            }
        }
    }
}
