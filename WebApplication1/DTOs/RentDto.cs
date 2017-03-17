using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class RentDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public CustomerDto Customer { get; set; }
        
        public ICollection<MovieDto> Movies { get; set; }

        public DateTime dateOfDeal { get; set; }

        public DateTime dateOfReturn { get; set; }
    }
}