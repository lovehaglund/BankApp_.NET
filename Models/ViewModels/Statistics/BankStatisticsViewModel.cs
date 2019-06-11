using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Domain.Models;

namespace BankApplication.Models
{
    public class BankStatisticsViewModel
    {
   
        public int NumberOfCustomers { get; set; }
        public int NumberOfAccounts { get; set; }
        public decimal? TotalAmount { get; set; }

        //Ska flyttas ut från denna viewmodel
        //public List<Customers> Customers { get; set; }

        //public BankStatisticsViewModel()
        //{
        //    Customers = new List<Customers>();
        //}
    }
}
