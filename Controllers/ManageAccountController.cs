using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.ViewModels;
using BankApplication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageAccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogin _loginRepo;
        private readonly IManageAccount _manageAccountRepo;
       //TODO FIXA UPDATE, SKICKA MED OCH TA BORT OLD ROLE?? HUR GÖRA?
        public ManageAccountController(ILogin loginRepo, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IManageAccount manageAccountRepo)
        {
            _manageAccountRepo = manageAccountRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _loginRepo = loginRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = _loginRepo.GetLoginInfo(model);

                if (user != null)
                {
                 
                        var result = await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, false, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    else
                    {
                        ModelState.AddModelError("", "Wrong password.");
                        return View();
                    }

                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> LogOff()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult RegisterAccount()
        {
            ManageAccountViewModel model = new ManageAccountViewModel();
            model.RoleList = _manageAccountRepo.GetRoles();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAccount(ManageAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleName = _manageAccountRepo.GetRoleName(model.RoleId);
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

            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult UpdateAccount(string id)
        {
            var model = _manageAccountRepo.GetUser(id);
            model.RoleList = _manageAccountRepo.GetRoles();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAccount(ManageAccountViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.CurrentUser.Id);
            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRoleAsync(user, roles[0]);

            var newRole = _manageAccountRepo.GetRoleName(model.RoleId);
            await _userManager.AddToRoleAsync(user, newRole);
            if (model.Password != null)
            {
                var removePassword = await _userManager.RemovePasswordAsync(user);

                if (removePassword.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
                else
                {
                    ModelState.AddModelError("", "Failed to remove old password");
                }
            }
            _manageAccountRepo.UpdateUser(model, user);
            return RedirectToAction("ManageUsers");
        }

        public IActionResult ManageUsers()
        {
            var model = _manageAccountRepo.GetUsers();
            
            return View(model);
        }
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(string id)
        {

            _manageAccountRepo.GetUserAndRemove(id);

            //Använd model.CurrentUser och ta bort den från databasen.

            return RedirectToAction("ManageUsers");
        }
      
    }
}
