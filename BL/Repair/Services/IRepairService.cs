using BL.Repair.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repair.Services
{
    public interface IRepairService
    {
        List<RepairDTO> GetAll();

        List<RepairDTO> GetAllByCarId(int carID);
        void AddRepair(RepairDTO repairDTO);
        void UpdateRepair(RepairDTO repairDTO);

        void AddNote(RepairDTO repairDTO);
        void UpdateNote(RepairDTO repairDTO);

        void DeleteRepair(RepairDTO repairDTO);
        void DeleteNote(RepairDTO repairDTO);
    }
}
