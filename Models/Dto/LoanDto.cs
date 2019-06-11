using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Dto
{
    public class LoanDto
    {
        public int LoanId { get; set; }
        public int AccountId { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public decimal Payments { get; set; }
        public string Status { get; set; }
    }
}
