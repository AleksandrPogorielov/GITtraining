using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
        
        public int GenreId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Premier Date")]
        public DateTime startedDate { get; set; }

        [EntryDateValidator]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Added Date")]
        public DateTime entryDate { get; set; }
        
        [MovieCount]
        public int count { get; set; }

        //public int? RentId { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }
}