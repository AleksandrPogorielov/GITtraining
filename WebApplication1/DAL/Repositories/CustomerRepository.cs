using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContext con)
            : base(con)
        {
                    
        }

        public ICollection<Customer> GetAllCustomers()
        {
            List<Customer> cust = new List<Customer>();

            foreach (var c in _context.Set<Customer>().Include(c => c.MembershipType))
            {
                cust.Add(c);
            }
            return cust;
        }        

        public override Customer GetById(int id)
        {
            Customer cust = new Customer();

            foreach (var c in _context.Set<Customer>().Include(c => c.MembershipType))
            {
                if (c.Id == id) 
                {
                    cust = c;
                    break;
                }
                
            }
            return cust;
        }
    }
}