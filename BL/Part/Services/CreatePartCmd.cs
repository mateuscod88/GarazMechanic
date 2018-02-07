using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Part.Services.Intefrace;
using DB;
using BL.Part.DTO;
using System.Data.Entity;

namespace BL.Part.Services
{
    public class CreatePartCmd : ICreatePart
    {
        private CarHistoryContext _context;
        public void Execute(PartDTO partDto)
        {

            using (_context = new CarHistoryContext())
            {
                //_context.Database.CreateIfNotExists();
                DB.Domain.Part part = new DB.Domain.Part();
                part.Name = partDto.Name;
                
                
                _context.Parts.Add(part);
                _context.SaveChanges();
            }
        }
    }
}
