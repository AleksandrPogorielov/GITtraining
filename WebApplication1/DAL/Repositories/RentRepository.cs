using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Linq.Expressions;
using System.Data.Entity;

namespace WebApplication1.DAL
{
    public class RentRepository : BaseRepository<Rent>, IRentRepository
    {
        public RentRepository(IDbContext con)
            : base(con)
        {
                    
        }

        public ICollection<Rent> GetAllRents()
        {
            List<Rent> rents = new List<Rent>();

            foreach (var c in _context.Set<Rent>().Include(c => c.Customer).Include(c => c.Movies))
            {
                rents.Add(c);
            }
            return rents;
        }

        //public override void Add(Rent entry)
        //{
        //    _context.Set<Rent>().Add(entry);
        //    foreach(Movie movId in entry.Movies)
        //    {
        //        _context.Set<Movie>();
        //        Movie mov=base.GetById(movId);
        //        base.Update(m);
        //    }
            
        //}
    }
}