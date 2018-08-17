using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGaraz.Models.Repair;

namespace WebGaraz.Models.Car
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Phone { get; set; }
        public string Year { get; set; }
        public string HorsePower { get; set; }
        public string PlateNumber { get; set; }
        public List<RepairModel> Repairs { get; set; }
    }
}