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
                Name = x.Name
            }).FirstOrDefault();
            return car;
        }
    }
}
