using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Services.Interface;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Services.Repositories
{
    public class BankStatisticsRepository : IBankStatistics
    {
        private readonly BankAppDataContext _context;

        public BankStatisticsRepository(BankAppDataContext context)
        {
            _context = context;
        }

        public BankStatisticsViewModel GetStats()
        {
            var model = new BankStatisticsViewModel();
            model.NumberOfAccounts = _context.Accounts.Count();
            model.NumberOfCustomers = _context.Customers.Count();
            model.TotalAmount = _context.Accounts.Select(c => c.Balance).Sum();

            return model;
        }
        //Ska flyttas ut från detta repo

        //public IndexStatisticsViewModel GetCustomerAndAccounts()
        //{
        //    var model = new IndexStatisticsViewModel();
        //    var test = _context.Customers.Include(c => c.Dispositions).ThenInclude(c => c.Account).ToList();
        //    model.Customers = test;
        //    return model;
        //}

    }
}
