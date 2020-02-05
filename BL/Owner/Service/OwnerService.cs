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
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone
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
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone
                }).FirstOrDefault();
            }
        }

        public void Add(OwnerDTO ownerDto)
        {
            try
            {
                var owner = _context.Owners.FirstOrDefault(x =>
                    x.LastName == ownerDto.LastName && x.FirstName == ownerDto.FirstName && x.Phone == ownerDto.Phone);
                if(owner == null)
                {
                    var newOwner = new DB.Domain.Owner()
                        {FirstName = ownerDto.FirstName, LastName = ownerDto.LastName, Phone = ownerDto.Phone};
                    _context.Owners.Add(newOwner);
                    _context.Save();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
