using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interface;
using System.Data.Entity;
using BL.Car.DTO;

namespace BL.Car.Services
{
    public class GetAllCarQuery : IGetAllCars
    {
        private IDatabaseService _context;
        public GetAllCarQuery(IDatabaseService context)
        {
            _context = context;
        }
        public List<CarDTO> Execute()
        {
           
            var Cars = _context
                   .Cars
                   .Select(x => new CarDTO
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
                       Repairs = _context.Repairs.Select(y => new BL.Repair.DTO.RepairDTO
                       {
                           Id = y.RepairID,
                           Date = (DateTime)y.DateRepair,
                           CarId= x.CarID,
                           Name = y.Name

                       }).ToList()


                   })
                       .ToList();
            return Cars;
            
        }
    }
}
