using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.Dto
{
    public class DispositionDto
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public string Type { get; set; }
    }
}
