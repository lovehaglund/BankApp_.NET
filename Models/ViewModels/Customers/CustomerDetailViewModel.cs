using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.Dto;
using Domain.Entities;

namespace BankApplication.Models
{
    public class CustomerDetailViewModel
    {
        public List<CustomerDto> Customers { get; set; }
        public List<AccountDto> CustomerAccounts { get; set; }
        public decimal TotalAmount { get; set; }
        public int currentAccountId;
        public int currentCustomerId;

        public CustomerDetailViewModel()
        {
            CustomerAccounts = new List<AccountDto>();
            Customers = new List<CustomerDto>();
        }
    }
}
