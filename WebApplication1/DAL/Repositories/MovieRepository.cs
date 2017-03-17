using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.DAL
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IDbContext con)
            : base(con)
        {
                    
        }

        public ICollection<Movie> GetAllMovies()
        {
            List<Movie> mov = new List<Movie>();

            foreach (var c in _context.Set<Movie>().Include(c => c.Genre))
            {
                mov.Add(c);
            }
            return mov;
        }

        public override Movie GetById(int id)
        {
            Movie cust = new Movie();

            foreach (var c in _context.Set<Movie>().Include(c => c.Genre))
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