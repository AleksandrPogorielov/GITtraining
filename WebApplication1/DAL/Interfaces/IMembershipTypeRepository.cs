using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    interface IMembershipTypeRepository: IReposytory<MembershipType>
    {
        ICollection<MembershipType> GetAllMembershipTypes();
    }
}
