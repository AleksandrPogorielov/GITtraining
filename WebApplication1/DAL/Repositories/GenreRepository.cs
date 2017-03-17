using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IDbContext con)
            : base(con)
        {
                    
        }

        public ICollection<Genre> GetAllGenres()
        {
            List<Genre> mem = new List<Genre>();

            foreach (var c in _context.Set<Genre>())
            {
                mem.Add(c);
            }
            return mem;
        }
    }
}