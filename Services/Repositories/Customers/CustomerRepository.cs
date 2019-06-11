using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models;
using BankApplication.Models.Dto;
using BankApplication.Services.Interface;
using Data.Context;
using Domain.Entities;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Services.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly BankAppDataContext _context;

        public CustomerRepository(BankAppDataContext context)
        {
            _context = context;
        }

        public CustomerDetailViewModel GetCustomerDetails(int id)
        {

            //|| c.CustomerId.ToString()
            //    .Equals(model.SearchString)).AsNoTracking()
            CustomerDetailViewModel model = new CustomerDetailViewModel();
            model.currentCustomerId = id;
            model.Customers = _context.Customers.Where(c => c.CustomerId == id).Select(c => new CustomerDto()
            {
                CustomerId = c.CustomerId,
                GivenName = c.Givenname,
                Surname = c.Surname,
                Address = c.Streetaddress,
                City = c.City,
                Birthday = c.Birthday,
                NationalId = c.NationalId
            }).ToList();

            var getDispositions = _context.Dispositions.Where(d => d.CustomerId == id).ToList();
            List<AccountDto> getAccounts = new List<AccountDto>();
            foreach (var g in getDispositions)
            {
                var account = _context.Accounts.Where(a => a.AccountId == g.AccountId).Select(a => new AccountDto
                {
                    AccountId = a.AccountId,
                    Balance = a.Balance,
                    Created = a.Created,
                    Frequency = a.Frequency
                }).ToList();
                foreach (var a in account)
                {
                    getAccounts.Add(a);
                }
            }

            model.CustomerAccounts = getAccounts;

            model.TotalAmount = getAccounts.Select(c => c.Balance).Sum();

            return model;
        }

        public CustomerViewModel GetCustomers(CustomerViewModel model)
        {

            var customerList = _context.Customers.Select(c => new CustomerDto()
            {
                CustomerId = c.CustomerId,
                GivenName = c.Givenname,
                Surname = c.Surname,
                Address = c.Streetaddress,
                City = c.City,
                NationalId = c.NationalId
            }).ToList();

            model.Customers = customerList;
            model.Offset = model.Limit * (model.PageNumber - 1);
            model.TotalPage = customerList.Count();
            model.NumberOfPages = model.TotalPage / model.Limit + 1;
            model.HasMorePages = model.Offset + model.Limit < model.TotalPage;
            model.Customers = customerList
                .Skip(model.Offset)
                .Take(model.Limit)
                .Select(c => new CustomerDto()
                {
                    CustomerId = c.CustomerId,
                    GivenName = c.GivenName,
                    Surname = c.Surname,
                    Address = c.Address,
                    City = c.City,
                    NationalId = c.NationalId

                })
                .ToList();

            return model;
        }

        public CustomerViewModel FilterCustomers(CustomerViewModel model, int page)
        {
            model.PageNumber = page == 0 ? 1 : page;
            model.Limit = 25;
            model.Offset = model.Limit * (model.PageNumber - 1);
            model.SearchName = model.SearchName ?? "";
            string[] splitResult = model.SearchName.Split(' ');

         
            

            IQueryable<Customers> result = _context.Customers;

            if (!string.IsNullOrEmpty(model.SearchName) || !string.IsNullOrEmpty(model.SearchCity))
            {
                if (!string.IsNullOrEmpty(model.SearchName) && !string.IsNullOrEmpty(model.SearchCity))
                {
                    result = result
                        .Where(c => c.Givenname.Contains(splitResult[0]) && c.City.Contains(model.SearchCity));
                }
                else
                {
                    if (string.IsNullOrEmpty(model.SearchName))
                    {
                        result = result.Where(c => c.City.Contains(model.SearchCity));
                    }
                    else
                    {
                        if (splitResult.Length > 1)
                        {

                            result = result
                                .Where(c => c.Givenname.Contains(splitResult[0]) && c.Surname.Contains(splitResult[1]));
                        }
                    

                        else
                        {
                             result = result
                                    .Where(c =>
                                        c.Givenname.Contains(model.SearchName) && c.City.Contains(model.SearchCity) || c
                                            .Givenname
                                            .Contains(model.SearchName) || c.Surname
                                            .Contains(model.SearchName) );
                        }
                       
                        
                         
                        
                        
                            
                    }

                }

              
                     if (splitResult.Length > 1 && (!splitResult[1].StartsWith(' ')))
                                    {
                                        if (!string.IsNullOrEmpty(model.SearchCity))
                                        {
                                            result = result
                                                .Where(c => c.Givenname.Contains(splitResult[0]) && c.Surname.Contains(splitResult[1]) &&
                                                            c.City.Contains(model.SearchCity));

                                        }
                                        else
                                        {
                                            result = result
                                                .Where(c => c.Givenname.Contains(splitResult[0]) && c.Surname.Contains(splitResult[1]));
                                        }

                                    }
                
               


                model.TotalPage = result.Count();
                model.NumberOfPages = model.TotalPage / model.Limit + 1;
                model.HasMorePages = model.Offset + model.Limit < model.TotalPage;
                model.Customers = result
                    .Skip(model.Offset)
                    .Take(model.Limit)
                    .Select(c => new CustomerDto()
                    {
                        CustomerId = c.CustomerId,
                        GivenName = c.Givenname,
                        Surname = c.Surname,
                        Address = c.Streetaddress,
                        City = c.City,
                        NationalId = c.NationalId

                    }).ToList();

                return model;

            }
            else
            {

                model.TotalPage = result.Count();
                model.NumberOfPages = model.TotalPage / model.Limit + 1;
                model.HasMorePages = model.Offset + model.Limit < model.TotalPage;
                model.Customers = result
                    .Skip(model.Offset)
                    .Take(model.Limit)
                    .Select(c => new CustomerDto()
                    {
                        CustomerId = c.CustomerId,
                        GivenName = c.Givenname,
                        Surname = c.Surname,
                        Address = c.Streetaddress,
                        City = c.City,
                        NationalId = c.NationalId

                    })
                    .ToList();
                return model;
            }

        }
    }
}
