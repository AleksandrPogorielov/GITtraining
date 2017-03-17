using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Rent
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        
        public ICollection<Movie> Movies { get; set; }

        public DateTime dateOfDeal { get; set; }

        public DateTime dateOfReturn { get; set; }
    }
}