using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApplication.Controllers
{
    //TODO Går så att det kommer antal sidor beroende på antal träffar,
    //TODO + 1 på next page och -1 på previous page ?

    [Authorize(Roles = "Cashier")]

    public class CustomerController : Controller
    {
        private ICustomer _customerRepo;

        public CustomerController(ICustomer customerRepo)
        {
            _customerRepo = customerRepo; 
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowCustomers(int page, CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = _customerRepo.FilterCustomers(model, page);
            }
            return View(model);
        }
        public IActionResult ShowCustomer(int id)
        {
            var model = new CustomerDetailViewModel();
            if (id >= 1)
            {
                model = _customerRepo.GetCustomerDetails(id);

            }

            return View(model);             
        }
    }
}
