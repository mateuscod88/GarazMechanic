using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repair.DTO
{
    public class RepairDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int updatedRepairNoteId { get; set; }
        public List<RepairNoteDTO> Notes { get; set; }
        public int CarId { get; set; }
    }
    public class RepairNoteDTO
    {
        public int Id { get; set; }
        public String Description { get; set; }
    }
}
