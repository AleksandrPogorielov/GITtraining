using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }
                
        public int GenreId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Premier Date")]
        public DateTime startedDate { get; set; }

        [Required]
        [EntryDateValidator]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Added Date")]
        public DateTime entryDate { get; set; }
                
        [MovieCount]
        public int count { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;            
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            startedDate = movie.startedDate;
            entryDate = movie.entryDate;
            count = movie.count;
            Genre = movie.Genre;
        }
    }
}