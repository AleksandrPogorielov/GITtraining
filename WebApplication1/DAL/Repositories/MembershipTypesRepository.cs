using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class MembershipTypesRepository: BaseRepository<MembershipType>, IMembershipTypeRepository
    {

        public MembershipTypesRepository(IDbContext con)
            : base(con)
        {
                    
        }

        public ICollection<MembershipType> GetAllMembershipTypes()
        {
            List<MembershipType> mem = new List<MembershipType>();

            foreach (var c in _context.Set<MembershipType>())
            {
                mem.Add(c);
            }
            return mem;
        }
    }
}