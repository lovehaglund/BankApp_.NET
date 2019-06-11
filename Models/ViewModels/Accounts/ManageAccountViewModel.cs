using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Models.ViewModels.ManageAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApplication.Models.ViewModels
{
    public class ManageAccountViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string OldRole { get; set; }
        public IdentityUser CurrentUser { get; set; }
        public List<UserModel> UserList { get; set; }
        public List<SelectListItem> RoleList { get; set; }

        public ManageAccountViewModel()
        {
            UserList = new List<UserModel>();
            RoleList = new List<SelectListItem>();
        }

    }
}
