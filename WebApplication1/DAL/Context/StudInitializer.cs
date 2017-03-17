using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    class StudInitializer : CreateDatabaseIfNotExists<StudContext>
    {
        protected override void Seed(StudContext context)
        {
            //Customer c1= new Customer() { Id = 1, DateOfBirth = 5, FirstName = "Rost", LastName = "Miroshnich"};
            //Customer c2= new Customer() { Id = 2, DateOfBirth = 32, FirstName = "Julia", LastName = "Brigik" };
            //Customer c3= new Customer() { Id = 3, DateOfBirth = 23, FirstName = "Maks", LastName = "Ninja" };
            //Customer c4= new Customer() { Id = 4, DateOfBirth = 6, FirstName = "Andrey", LastName = "DeerHunter" };
            //Customer c5 = new Customer() { Id = 5, DateOfBirth = 45, FirstName = "Aleks", LastName = "Pog" };

            // Customer[] c={c1, c2, c3, c4, c5};
            // context.customers.AddRange(c);
            // context.SaveChanges();
        }
    }
}
