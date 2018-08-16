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
            List<CarDTO> Cars;
            Cars = _context
                   .Cars
                   .Select(x => new CarDTO
                   {
                       Id = x.CarID,
                       Name = x.Name,
                       Year = x.ProductionYear != null ? x.ProductionYear.Year : "",
                       PlateNumber = x.PlateNumber,
                       Phone = x.Owner != null ? x.Owner.Phone : "",
                       Brand = x.Brand != null ? x.Brand.Name : "",
                       BrandId = x.Brand != null ? x.Brand.BrandID : 0,
                       HorsePower = x.HorsePower,
                       OwnerName = x.Owner != null ? x.Owner.Name : "",
                       Model = x.Model != null ? x.Model.Name : "",
                       ModelId = x.Model != null ? x.Model.ModelID : 0,
                       Repairs = x.Repairs.Select(y => new Repair.DTO.RepairDTO
                       {
                           Id = y.RepairID,
                           Name = y.Name,
                           Date = y.RepairDate
                       }).ToList()

                       })
                       .ToList();
            return Cars;
            
        }
    }
}
