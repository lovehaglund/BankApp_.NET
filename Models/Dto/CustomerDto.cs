using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class CustomerDto
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public DateTime? Birthday { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }
        public string ZipCode { get; set; }
    }
}
