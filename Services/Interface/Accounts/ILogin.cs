using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BankApplication.Services.Interface
{
    public interface ILogin
    {
        IdentityUser GetLoginInfo(LoginViewModel model);
    }
}
