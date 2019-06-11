using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Services.Interface
{
    public interface IManageAccount
    {
       Task<ManageAccountViewModel> RegisterAccount(ManageAccountViewModel model);
        void UpdateUser(ManageAccountViewModel model, IdentityUser user);
        void GetUserAndRemove(string id);
        List<SelectListItem> GetRoles();
        string GetRoleName(string id);
        ManageAccountViewModel GetUsers();
        ManageAccountViewModel GetUser(string id);

    }
}
