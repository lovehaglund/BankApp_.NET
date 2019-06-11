using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Models
{
    public class TransactionViewModel
    {
        public List<TransactionDto> Transaction { get; set; }

        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{1,13}(?:\,[0-9]{0,2})?$", ErrorMessage = "Invalid amount")]
        public decimal Amount { get; set; }
        public bool AmountValid { get; set; }
        public bool AccountExist { get; set; }
        public DateTime Date { get; set; }
        public List<SelectListItem> AccountList { get; set; }

        public TransactionViewModel()
        {
            Transaction = new List<TransactionDto>();
        }
    }
}
