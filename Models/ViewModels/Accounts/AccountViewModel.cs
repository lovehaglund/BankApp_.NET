using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AccountDto = BankApplication.Models.Dto.AccountDto;

namespace BankApplication.Models
{
    public class AccountViewModel
    {
        public List<TransactionDto> Transactions { get; set; }
        public List<AccountDto> Accounts { get; set; }
        public List<LoanDto> Loans { get; set; }
        public int CurrentAccountId { get; set; }
        public int PageNumber { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalPage { get; set; }
        public int NumberOfPages { get; set; }
        public bool HasMorePages { get; set; }
        public int Id { get; set; }
        public AccountViewModel()
        {
            Transactions = new List<TransactionDto>();
            Accounts = new List<AccountDto>();
            Loans = new List<LoanDto>();
        }
    }
}
