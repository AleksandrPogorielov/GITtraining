using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MovieCount: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.count >= 1 && movie.count <= 20)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Кол-во копий не может быть менее 1 и более 20");
        }
    }
}