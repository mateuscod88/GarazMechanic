using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Repair.DTO;
namespace BL.Car.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public string  OwnerName { get; set; }
        public string Phone { get; set; }
        public string Year { get; set; }
        public string HorsePower { get; set; }
        public string PlateNumber { get; set; }
        public List<RepairDTO> Repairs { get; set; }

    }
}
