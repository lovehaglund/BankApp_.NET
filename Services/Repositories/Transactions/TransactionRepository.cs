using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BankApplication.Models;
using BankApplication.Models.Dto;
using BankApplication.Services.Interface;
using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Services.Repositories
{
    public class TransactionRepository : ITransaction
    {
        private BankAppDataContext _context;

        public TransactionRepository(BankAppDataContext context)
        {
            _context = context;
        }

        public TransactionViewModel Transfer(TransactionViewModel model)
        {
            model.Date = DateTime.Now;
            string sqlFormattedDate = model.Date.ToString("yyyy-MM-dd");
            model.AmountValid = true;
            model.AccountExist = true;

            var contextAccounts = _context.Accounts.Select(c => c.AccountId);

            if (contextAccounts.Contains(model.FromAccount) && contextAccounts.Contains(model.ToAccount))
            {
                var fromAccount = _context.Accounts.SingleOrDefault(a => a.AccountId == model.FromAccount);
                var toAccount = _context.Accounts.SingleOrDefault(a => a.AccountId == model.ToAccount);
                if (model.Amount > fromAccount.Balance)
                {
                    model.AmountValid = false;
                    return model;

                }
                var amount = Math.Round(model.Amount, 2);

                Transactions transactionFrom = new Transactions
                {
                    AccountId = model.FromAccount,
                    Amount = amount * -1,
                    Date = DateTime.Parse(sqlFormattedDate),
                    Type = "Credit",
                    Operation = "Transfer",
                    Balance = fromAccount.Balance - amount,
                    AccountNavigation = fromAccount

                };
                Transactions transactionTo = new Transactions
                {
                    AccountId = model.ToAccount,
                    Amount = amount,
                    Date = DateTime.Parse(sqlFormattedDate),
                    Type = "Debit",
                    Operation = "Transfer",
                    Balance = toAccount.Balance + amount,
                    AccountNavigation = toAccount

                };
                toAccount.Balance = toAccount.Balance + amount;
                fromAccount.Balance = fromAccount.Balance - amount;
                _context.Transactions.Add(transactionFrom);
                _context.Transactions.Add(transactionTo);
                _context.SaveChanges();

                return model;
            }
            else
            {
                model.AccountExist = false;
                return model;

            }
        }
        public TransactionViewModel Withdraw(TransactionViewModel model)
        {
            model.Date = DateTime.Now;
            string sqlFormattedDate = model.Date.ToString("yyyy-MM-dd");

            model.AmountValid = true;
            var contextAccounts = _context.Accounts.Select(c => c.AccountId);

            if (contextAccounts.Contains(model.FromAccount))
            {
                var chosenAccount = _context.Accounts.SingleOrDefault(a => a.AccountId == model.FromAccount);
                if (model.Amount > chosenAccount.Balance)
                {
                    model.AmountValid = false;
                    return model;

                }
                var amount = Math.Round(model.Amount, 2);

                Transactions transaction = new Transactions
                {
                    AccountId = model.FromAccount,
                    Amount = amount * -1,
                    Date = DateTime.Parse(sqlFormattedDate),
                    Type = "Credit",
                    Operation = "Withdrawal in Cash",
                    Balance = chosenAccount.Balance - amount,
                    AccountNavigation = chosenAccount

                };

                chosenAccount.Balance = chosenAccount.Balance - amount;
                _context.Transactions.Add(transaction);
                _context.SaveChanges();

                return model;
            }

            return model;
        }

        public TransactionViewModel Deposit(TransactionViewModel model)
        {

            model.Date = DateTime.Now;
            string sqlFormattedDate = model.Date.ToString("yyyy-MM-dd");
            model.AmountValid = true;



            var contextAccounts = _context.Accounts.Select(c => c.AccountId);
            if (contextAccounts.Contains(model.ToAccount))
            {
                var chosenAccount = _context.Accounts.SingleOrDefault(a => a.AccountId == model.ToAccount);

               var amount = Math.Round(model.Amount, 2);

                Transactions transaction = new Transactions
                {
                    AccountId = model.ToAccount,
                    Amount = amount,
                    Date = DateTime.Parse(sqlFormattedDate),
                    Type = "Debit",
                    Operation = "Deposit",
                    Balance = chosenAccount.Balance + amount,
                    AccountNavigation = chosenAccount
                    
                };

                chosenAccount.Balance = chosenAccount.Balance + model.Amount;
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                
                return model;
            }

            return model;
        }
        public List<SelectListItem> GetAccounts(int id)
        {
            return _context.Accounts.Where(a=>a.AccountId == id).Select(r => new SelectListItem
            {
                Value = r.AccountId.ToString(),
                Text = r.AccountId.ToString()
            }).ToList();
        }
      
    }
}
