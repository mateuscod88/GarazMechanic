using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Car.Services;
using BL.Part.Services;

namespace GarazConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            // CreateCarCmd cmd = new CreateCarCmd();
            // cmd.Execute();
            
            CreatePartCmd cmd = new CreatePartCmd();
            cmd.Execute(new BL.Part.DTO.PartDTO() { Name = "wahacz"});

             GetAllCarQuery query = new GetAllCarQuery();
            List<BL.Car.DTO.Car> cars = query.Execute();
            foreach(var car in cars)
            {
                Console.WriteLine(car.Name);
            }
        }
    }
}
