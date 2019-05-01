using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGaraz.Models.RepairNote;
using System.ComponentModel.DataAnnotations;
using System.Net;
namespace WebGaraz.Models.Repair
{
    public class RepairModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Repair Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Repair Date is Required")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Note is Required")]
        public string Note { get; set; }
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
    }
}