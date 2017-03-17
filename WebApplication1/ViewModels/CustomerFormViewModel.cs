using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string OperationName { get; set; }

        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Min18yearformembership]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfBirth { get; set; }

        public bool IsSubscribed { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        public CustomerFormViewModel(string oper)
        {
            Id = 0;
            OperationName = oper;
        }

        public CustomerFormViewModel(string oper, Customer customer)
        {
            OperationName = oper;

            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            DateOfBirth = customer.DateOfBirth;
            IsSubscribed = customer.IsSubscribed;
            MembershipType = customer.MembershipType;
            MembershipTypeId = customer.MembershipTypeId;
        }
    }
}