using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Services.Interface
{
    public interface ICustomer
    {
        CustomerViewModel GetCustomers(CustomerViewModel model);
        CustomerViewModel FilterCustomers(CustomerViewModel model,int page);
        CustomerDetailViewModel GetCustomerDetails(int id);
    }
}
