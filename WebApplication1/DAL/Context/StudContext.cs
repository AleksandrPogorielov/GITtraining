using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace WebApplication1.DAL
{
    public class StudContext:DbContext, IDbContext
    {
        public StudContext()
            : base("DBConnection")
        {
            Database.SetInitializer<StudContext>(new StudInitializer());
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<MembershipType> memberships { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Rent> rents { get; set; }
    }
}
