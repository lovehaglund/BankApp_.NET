using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace BankApplication.Models
{
    public class CustomerViewModel
    {

        public List<CustomerDto> Customers { get; set; }
        [RegularExpression(@"[a-zA-Z'\s]*$", ErrorMessage = "Use A-Z/a-z")]
        public string SearchName { get; set; }
        [RegularExpression(@"[a-zA-Z'\s]*$", ErrorMessage = "Use A-Z/a-z")]
        public string SearchCity { get; set; }
        public int SearchId { get; set; }
        public int PageNumber { get; set; } 
        public int Limit { get; set; } 
        public int Offset { get; set; } 
        public int TotalPage { get; set;}
        public int NumberOfPages { get; set; }
        public bool HasMorePages { get; set; }
        public int Id { get; set; }

        
        public CustomerViewModel()
        {
      
            Customers = new List<CustomerDto>();
        }

    }
}
