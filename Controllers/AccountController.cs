using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Services.Interface;
using BankApplication.Services.Repositories;
using Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApplication.Controllers
{
    public class AccountController : Controller
    {
        private IAccount _accountRepo;
        public AccountController(IAccount accountRepo)
        {
            _accountRepo = accountRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAccountInfo(int id,int page = 1)
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            var model = new AccountViewModel();
            model = _accountRepo.GetTransactions(id, page);
            if (isAjax)
            {
                return PartialView("_TransactionPartial", model);

            }
            else
            {
                return View(model);
            }

        }
   
    }
}
