using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Min18yearformembership: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.Free)
            {
                return ValidationResult.Success;
            }

            if (!customer.DateOfBirth.HasValue)
            {
                return new ValidationResult("Please set date of birth");
            }

            try
            {
                var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;
                return (age >= 18) ? ValidationResult.Success : new ValidationResult("You are too small!!!");
            }
            catch
            {
                return new ValidationResult("Please set date of birth in the correct format"); 
            }

            
        }
    }
}