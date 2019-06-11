using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankApplication.Models;
using BankApplication.Services.Interface;
using BankApplication.Services.Repositories;
using Microsoft.AspNetCore.Identity;


namespace BankApplication.Controllers
{

    //TODO Fixa så det går att söka på namn och efternamn samtidigt, en till input?
    //TODO Lägg in validering på sök, om det inte finns några namn/id som matchar så ska man få en text" Finns inga matchningar "
    //TODO Lägg in validering på alla fält,
    //TODO Lägg in Model.state övereallt & Antiforgery
  

    public class HomeController : Controller
    {
        private IBankStatistics _indexStats;
        private readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(IBankStatistics indexStats, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _indexStats = indexStats;
        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole("Cashier"))
                {
                var model = _indexStats.GetStats();
                return View(model);
                }
                else
                {
                    return View("AdminStart");
                }
             
            }
            else
            {
                return RedirectToAction("Login", "ManageAccount");
            }
        }

     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
