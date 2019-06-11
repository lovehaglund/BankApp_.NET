using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.ViewModels;
using BankApplication.Services.Interface;
using Data.Context;
using Microsoft.AspNetCore.Identity;

namespace BankApplication.Services.Repositories
{
    public class LoginRepository : ILogin
    {
        private BankAppDataContext _context;
        public LoginRepository(BankAppDataContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
        }
        public IdentityUser GetLoginInfo(LoginViewModel model)
        {

            var user = _context.Users.SingleOrDefault(u => u.UserName == model.UserName);
            if (user == null)
            {
                return user;
            }
            var _user = new IdentityUser()
            {
                UserName = model.UserName,
                PasswordHash = model.Password,
            };

            return _user;
        }
    }
}
