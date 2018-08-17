using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGaraz.Models.RepairNote;

namespace WebGaraz.Models.Repair
{
    public class RepairModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int updatedRepairNoteId { get; set; }
        public List<RepairNoteModel> Notes { get; set; }
        public int CarId { get; set; }
    }
}