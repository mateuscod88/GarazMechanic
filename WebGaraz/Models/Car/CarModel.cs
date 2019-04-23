using BL.Repair.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGaraz.Models.Repair;

namespace WebGaraz.Models.Car
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Car Brand is Required")]
        public int BrandId { get; set; }
        public string Brand { get; set; }
        [Required(ErrorMessage = "Car Model is Required")]
        public int ModelId { get; set; }
        public string Model { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Phone { get; set; }
        public string Year { get; set; }
        public string HorsePower { get; set; }
        public string Engine { get; set; }
        [Required(ErrorMessage = "Plate number required")]
        public string PlateNumber { get; set; }
        public string TechnicalCheck { get; set; }
        public string LatestOilChange { get; set; }
        public List<RepairDTO> Repairs { get; set; }
    }
}