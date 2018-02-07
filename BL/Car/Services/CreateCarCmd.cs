using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Car.Services
{
    public class CreateCarCmd
    {
        private CarHistoryContext _context;
        public void Execute()
        {
            using (_context = new CarHistoryContext())
            {
                DB.Domain.Car car = new DB.Domain.Car();
                car.Name = "audi";
                car.Model = null;
                car.Brand = null;
                car.Owner = null;
                car.Repairs = null;
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
        }
    }
}
