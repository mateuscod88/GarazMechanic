using BL.Repair.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Interface;
namespace BL.Repair.Services
{
    public class RepairService : IRepairService
    {
        private IDatabaseService _context;
        public RepairService(IDatabaseService context)
        {
            _context = context;
        }
        public List<RepairDTO> GetAll()
        {
            using (_context)
            {

                var repairs = _context.Repairs.Select(x => new RepairDTO
                {
                    Id = x.RepairID,
                    Name = x.Name,
                    Date = (DateTime)x.DateRepair,
                    CarId = x.CarID,
                    Brand = x.Car.Brand.Name,
                    Model = x.Car.Model.Name,
                    PlateNumber = x.Car.PlateNumber,
                    Note = x.Note
                }).ToList();

                return repairs;
            }
            
        }
        public List<RepairDTO> GetAllByCarId(int carID)
        {
            using (_context)
            {
                var carRepairs = _context.Repairs.Where(x => x.Car.CarID == carID).Select(x => new RepairDTO
                {
                    Id = x.RepairID,
                    Name = x.Name,
                    Date = (DateTime)x.DateRepair
                }).ToList();
                return carRepairs;
            }
        }
        public void AddRepair(RepairDTO repairDTO)
        {
            using (_context)
            {
                var car = _context.Cars.Where(x => x.CarID == repairDTO.CarId).FirstOrDefault();
                
                _context.Repairs.Add(new DB.Domain.Repair
                {
                    Name = repairDTO.Name,
                    DateRepair = repairDTO.Date,
                    Note = repairDTO.Note,
                    Car = car                    
                });
                _context.Save();
            }
        }
        public void UpdateRepair(RepairDTO repairDTO)
        {
            using (_context)
            {
               
                var repair = _context.Repairs.Where(x => x.RepairID == repairDTO.Id).FirstOrDefault();
                repair.DateRepair = repair.DateRepair != repairDTO.Date ? repairDTO.Date : repair.DateRepair;
                repair.Name = repair.Name != repairDTO.Name ? repairDTO.Name : repair.Name;
                _context.Save();
            }
        }

        public void AddNote(RepairDTO repairDTO) {
            using (_context)
            {
                var repair = _context.Repairs.Where(x => x.RepairID == repairDTO.Id).FirstOrDefault();

                _context.RepairNotes.Add(new DB.Domain.RepairNotes
                {
                    Repair = repair,

                });
                 
                
                _context.Save();

            }
        }
        public void UpdateNote(RepairDTO repairDTO) {
            using (_context)
            {
                _context.Save();
            }
            
        }

        public void DeleteRepair(RepairDTO repairDTO)
        {
            using (_context)
            {
                _context.Repairs.Where(x => x.RepairID == repairDTO.Id).FirstOrDefault().IsInactive = "Y";
                var repairNotes = _context.RepairNotes.ToList();
                foreach(var repairNote in repairNotes)
                {
                    repairNote.IsInactive = "Y";
                }
                _context.Save();
            }
        }
        public void DeleteNote(RepairDTO repairDTO)
        {
            using (_context)
            {
                _context.Save();
            }
            
        }

    }
}
