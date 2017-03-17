using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace DAL
{
    class StudContext:DbContext
    {
        public StudContext()
            : base("DBConnection")
        {
            Database.SetInitializer<StudContext>(new StudInitializer());
        }

        DbSet<Customer> customers { get; set; }
    }
}
