using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BankApplication.Models;
using BankApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Services.Interface
{
   public interface IManageCustomer
    {
       ManageCustomerViewModel RegisterCustomer(ManageCustomerViewModel model);
        ManageCustomerViewModel UpdateCustomer(ManageCustomerViewModel model);
        ManageCustomerViewModel GetCustomer(int id);
        List<SelectListItem> GetGender();
    }
}
