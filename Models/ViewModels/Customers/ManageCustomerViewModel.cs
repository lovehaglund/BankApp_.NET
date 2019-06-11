using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Models.ViewModels
{
    public class ManageCustomerViewModel
    {
        public Customers customer { get; set; }
        public List<Customers> Customers { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖA\s]+$", ErrorMessage = "Use a-z/åäö")]
        [MinLength(1, ErrorMessage = "Min length is 1 characters")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string GivenName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖA\s]+$", ErrorMessage = "Use a-z/åäö")]
        [MinLength(1, ErrorMessage = "Min length is 1 characters")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖA\s]+$", ErrorMessage = "Use a-z/åäö")]
        [MinLength(1, ErrorMessage = "Min length is 1 characters")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MinLength(1, ErrorMessage = "Min length is 1 characters")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Address { get; set; }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "National ID is required")]
        [MinLength(1, ErrorMessage = "Min length is 1 characters")]
        [MaxLength(20, ErrorMessage = "Max length is 20 characters")]
        public string NationalId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Email { get; set; }

        public int AccountId { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖA\s]+$", ErrorMessage = "Use a-z/åäö")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        [RegularExpression(@"^[a-zåäöA-ZÅÄÖA\s]+$", ErrorMessage = "Use a-z/åäö")]
        [MinLength(1, ErrorMessage = "Min length is 1 characters")]
        [MaxLength(2, ErrorMessage = "Max length is 2 characters")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Choose a gender")]
        public string ChosenGender { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Max length is 15 characters")]
        [MinLength(1, ErrorMessage = "Min length is 1 characters")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Choose a gender")]
        public List<SelectListItem> Gender { get; set; }
        public ManageCustomerViewModel()
        {
            Gender = new List<SelectListItem>();
            Customers = new List<Customers>();
        }
    }
}
