using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.ViewModels;
using BankApplication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApplication.Controllers
{
    // Ändra namn på RegisterCustomerViewModel...
    //FIXA UPDATE METODEN ( KOLLA UTBILDINGSSTYSTEM)
    [Authorize(Roles = "Cashier")]

    public class ManageCustomerController : Controller
    {
        private IManageCustomer _manageCustomerRepo;

        public ManageCustomerController(IManageCustomer manageCustomerRepo)
        {
            _manageCustomerRepo = manageCustomerRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegisterCustomer()
        {
            var model = new ManageCustomerViewModel();
            model.Gender = _manageCustomerRepo.GetGender();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCustomer(ManageCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _manageCustomerRepo.RegisterCustomer(model);
                return RedirectToAction("ShowAccountInfo", "Account", new { id = model.AccountId });
            }

            model.Gender = _manageCustomerRepo.GetGender();
            return View(model);
        }

        public IActionResult UpdateCustomer(int id)
        {
            var model = new ManageCustomerViewModel();
            model = _manageCustomerRepo.GetCustomer(id);
            model.Gender = _manageCustomerRepo.GetGender();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer(ManageCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _manageCustomerRepo.UpdateCustomer(model);
                return RedirectToAction("ShowCustomer","Customer", new { id = model.CustomerId });
            }
            return View(model);

        }
    }
}
