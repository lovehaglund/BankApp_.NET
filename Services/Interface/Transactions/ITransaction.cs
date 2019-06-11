using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;

namespace BankApplication.Services.Interface
{
    public interface ITransaction
    {
        TransactionViewModel Deposit(TransactionViewModel model);
        TransactionViewModel Withdraw(TransactionViewModel model);
        TransactionViewModel Transfer(TransactionViewModel model);
    }
}
