using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        
        public DateTime startedDate { get; set; }

        //[EntryDateValidator]        
        public DateTime entryDate { get; set; }

        //[MovieCount]
        public int count { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}