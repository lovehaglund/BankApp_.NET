using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApplication.Controllers
{

    //Systemet ska också hantera insättningar, uttag och överföringar mellan konton.Det får inte bli några
    //avrundningsfel så använd rätt typ för saldo och belopp som är pengar.
    [Authorize(Roles = "Cashier")]
    public class TransactionController : Controller
    {
        private ITransaction _transactRepo;
        public TransactionController(ITransaction transactRepo)
        {
            _transactRepo = transactRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Deposit(int id)
        {
            TransactionViewModel model = new TransactionViewModel();
            model.ToAccount = id;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionViewModel model)
        {
            if (model.Amount < ((decimal)0.01))
            {
                ModelState.AddModelError("", "Minimum amount is 0,01");
                return View(model);
            }
            model = _transactRepo.Deposit(model);
            return RedirectToAction("ShowAccountInfo","Account", new { id = model.ToAccount });

            //return View(model);
        }

        public IActionResult Withdraw(int id)
        {
            var model = new TransactionViewModel();
            model.FromAccount = id;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(TransactionViewModel model)
        {
            if (model.Amount < ((decimal)0.01))
            {
                ModelState.AddModelError("", "Minimum amount is 0,01");
                return View(model);
            }
            model = _transactRepo.Withdraw(model);
          
            if (model.AmountValid == false)
            {
                ModelState.AddModelError("", "You dont have enough money");
                return View(model);
            }
            return RedirectToAction("ShowAccountInfo", "Account", new { id = model.FromAccount });
        }

        public IActionResult Transfer(int id)
        {

            var model = new TransactionViewModel();
            model.FromAccount = id;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransactionViewModel model)
        {
            if (model.FromAccount == model.ToAccount)
            {
                ModelState.AddModelError("", "Try another account");
                return View(model);
            }

            if (model.Amount <= (decimal)0.01)
            {
                ModelState.AddModelError("", "Minimum amount is 0,01");
                return View(model);
            }
            model = _transactRepo.Transfer(model);

            if (model.AccountExist == false)
            {
                ModelState.AddModelError("", "Try another account");
                return View(model);
            }
            if (model.AmountValid == false)
            {
                ModelState.AddModelError("", "You dont have enough money");
                return View(model);
            }
            return RedirectToAction("ShowAccountInfo", "Account", new { id = model.FromAccount });
        }
    }
}
