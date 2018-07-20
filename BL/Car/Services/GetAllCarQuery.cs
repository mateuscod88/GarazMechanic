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
                       .Select(car => new CarDTO
                       {
                           Id = car.CarID,
                           Name = car.Name
                       })
                       .ToList();
            return Cars;
            
        }
    }
}
