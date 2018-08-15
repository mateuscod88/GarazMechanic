using BL.Owner.DTO;
using DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Owner.Service
{
    public class OwnerService : IOwnerService
    {
        private IDatabaseService _context;
        public OwnerService(IDatabaseService context)
        {
            _context = context;
        }
        public List<OwnerDTO> GetAll()
        {
            using (_context)
            {
                return _context.Owners.Select(x => new OwnerDTO
                {
                    ID = x.OwnerID,
                    Name = x.Name
                }).ToList();
            }
        }
        public OwnerDTO GetById(int ownerId)
        {
            using (_context)
            {
                return _context.Owners.Where(x => x.OwnerID == ownerId).Select(x => new OwnerDTO
                {
                    ID = x.OwnerID,
                    Name = x.Name
                }).FirstOrDefault();
            }
            
        }
    }
}
