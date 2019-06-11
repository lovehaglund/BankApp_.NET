using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Models.Dto;
using BankApplication.Services.Interface;
using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace BankApplication.Services.Repositories
{
    public class AccountRepository : IAccount 
    {
        private BankAppDataContext _context; 
        private IHttpContextAccessor _contextAccess;
        public AccountRepository(BankAppDataContext context, IHttpContextAccessor contextAccess)
        {
            _contextAccess = contextAccess;
            _context = context;
        }
        
        public AccountViewModel GetTransactions(int id, int page)
        {
            IQueryable<Transactions> result = _context.Transactions;

            AccountViewModel model = new AccountViewModel();
            model.Accounts = _context.Accounts.Where(a => a.AccountId == id).Take(1).Select(a => new AccountDto
            {
                AccountId = a.AccountId,
                Balance = a.Balance,
                Created = a.Created,
                Frequency = a.Frequency
            }).ToList();

            foreach (var a in model.Accounts)
            {
                model.CurrentAccountId = a.AccountId;
            }

            model.PageNumber = page == 0 ? 1 : page;

            model.Limit = 10;
            model.Offset = model.Limit * (model.PageNumber - 1);

            result = result.Where(t => t.AccountId == id).OrderByDescending(i => i.TransactionId);
          

            model.TotalPage = result.Count();
            model.NumberOfPages = model.TotalPage / model.Limit + 1;
            model.HasMorePages = model.Limit < model.TotalPage;
            model.Transactions = result
                .Skip(model.Offset)
                .Take(model.Limit)
                .OrderByDescending(i => i.TransactionId)
                .Select(t => new TransactionDto()
                {
                    TransactionId = t.TransactionId,
                    AccountId = t.AccountId,
                    Amount = t.Amount,
                    Balance = t.Balance,
                    Date = t.Date,
                    Operation = t.Operation,
                    Type = t.Type

                })
                .ToList();
          
            return model;
        }
    }
}
