using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EntryDateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            int compareresult=DateTime.Compare(movie.entryDate, movie.startedDate);

            if (compareresult==1)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Дата добавления не может быть раньше даты выхода фильма");
        }
    }
}