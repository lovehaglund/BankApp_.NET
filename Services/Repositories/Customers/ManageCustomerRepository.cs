using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Models.Dto;
using BankApplication.Models.ViewModels;
using BankApplication.Services.Interface;
using Data.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Services.Repositories
{
    public class ManageCustomerRepository : IManageCustomer
    {
        private BankAppDataContext _context;

        public ManageCustomerRepository(BankAppDataContext context)
        {
            _context = context;
        }

        
        public ManageCustomerViewModel RegisterCustomer(ManageCustomerViewModel model)
        {
            
        var newCustomer = new Customers()
            {
                Givenname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.GivenName),
                Surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Surname),
                Emailaddress = model.Email.ToLower(),
                Streetaddress = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Address),
                City = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.City),
                NationalId = model.NationalId,
                Country = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Country),
                CountryCode = model.CountryCode.ToUpper(),
                Gender = model.ChosenGender,
                Zipcode = model.ZipCode
            };
            _context.Customers.Add(newCustomer);

            var newAccount = new Accounts()
            {
                Created = DateTime.Now,
                Balance = 0,
                Frequency = "Monthly"
            };
            _context.Accounts.Add(newAccount);

            var newDisposition = new Dispositions
            {
                Account = newAccount,
                Customer = newCustomer,
                Type = "Owner"
            };
           
            _context.Dispositions.Add(newDisposition);
           
            _context.SaveChanges();
            model.AccountId = newAccount.AccountId;
            return model;
        }

        public ManageCustomerViewModel GetCustomer(int id)
        {
            ManageCustomerViewModel model = new ManageCustomerViewModel();
            model.Customers = _context.Customers.Where(c => c.CustomerId == id).ToList();
            model.CustomerId = id;

            foreach (var c in model.Customers)
            {
                model.GivenName = c.Givenname;
                model.Surname = c.Surname;
                model.Email = c.Emailaddress;
                model.Address = c.Streetaddress;
                model.City = c.City;
                model.NationalId = c.NationalId;
                model.Country = c.Country;
                model.CountryCode = c.CountryCode;
                model.ChosenGender = c.Gender;
                model.ZipCode = c.Zipcode;
            
            }
               
            return model;
        }
      
        public ManageCustomerViewModel UpdateCustomer(ManageCustomerViewModel model)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == model.CustomerId);

            customer.Givenname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.GivenName);
            customer.Surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Surname);
            customer.Emailaddress = model.Email.ToLower();
            customer.Streetaddress = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Address);
            customer.City = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.City);
            customer.NationalId = model.NationalId;
            customer.Country = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(model.Country);
            customer.CountryCode = model.CountryCode.ToUpper();
            customer.Gender = model.ChosenGender;
            customer.Zipcode = model.ZipCode;
            _context.SaveChanges();
            return model;
        }

        public List<SelectListItem> GetGender()
        {
            ManageCustomerViewModel model = new ManageCustomerViewModel();
            
            var male = new SelectListItem()
            {
                Value = "Male",
                Text = "Male"
            }; 
            var female = new SelectListItem()
            {
                Value = "Female",
                Text = "Female"
            };
            model.Gender.Add(male);
            model.Gender.Add(female);

            return model.Gender;
        }
    }
}
