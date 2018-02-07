using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Car.Services
{
    public class GetAllCarQuery
    {
        private CarHistoryContext _context;
        public List<BL.Car.DTO.Car> Execute()
        {
            List<BL.Car.DTO.Car> Cars;
            using (_context = new CarHistoryContext())
            {
                Cars = _context
                       .Cars
                       .Select(car => new BL.Car.DTO.Car()
                       {
                           Id = car.CarID,
                           Name = car.Name
                       })
                       .ToList();
            }
            return Cars;
            
        }
    }
}
