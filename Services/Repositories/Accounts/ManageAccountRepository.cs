using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Models.ViewModels;
using BankApplication.Models.ViewModels.ManageAccount;
using BankApplication.Services.Interface;
using Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Services.Repositories
{
    public class ManageAccountRepository : IManageAccount
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BankAppDataContext _context;
        private readonly SignInManager<IdentityUser> _singInManager;

        public ManageAccountRepository(UserManager<IdentityUser> userManager, BankAppDataContext context, SignInManager<IdentityUser> signInManager)
        {
            _singInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }
        public async Task<ManageAccountViewModel> RegisterAccount(ManageAccountViewModel model)
        {
            var roleName = GetRoleName(model.RoleId);
            var userIdentity = new IdentityUser()
            {
                UserName = model.UserName,
                PasswordHash = model.Password,
            };

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userIdentity, roleName);
            }
           
                //await _singInManager.SignInAsync(userIdentity, isPersistent: false);
            

            return model;
        }
        public List<SelectListItem> GetRoles()
        {
            return _context.Roles.Select(r => new SelectListItem
            {
                Value = r.Id,
                Text = r.Name
            }).ToList();
            
        }
        public string GetRoleName(string id)
        {
            ManageAccountViewModel model = new ManageAccountViewModel();
            var roleName = _context.Roles.Where(r => r.Id == id).Select(x => x.Name).SingleOrDefault();
            model.OldRole = roleName;
            return roleName;
        }

        public ManageAccountViewModel GetUser(string id)
        {
            var model = new ManageAccountViewModel();
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            model.CurrentUser = user;
            return model;
        }
        public ManageAccountViewModel GetUsers()
        {
            var model = new ManageAccountViewModel();

            var users = (from user in _context.Users
                join userRole in _context.UserRoles on user.Id equals userRole.UserId
                join role in _context.Roles on userRole.RoleId equals role.Id
                select new UserModel()
                {
                    UserName = user.UserName,
                    RoleName = role.Name,
                    Id = user.Id
                }).ToList();
            foreach (var u in users)
            {
                model.UserList.Add(u);
            }

            return model;
        }

        public void UpdateUser(ManageAccountViewModel model, IdentityUser user)
        {
            user.UserName = model.UserName;
         
            _context.SaveChanges();

        }
        public void GetUserAndRemove(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
