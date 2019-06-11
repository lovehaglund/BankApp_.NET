using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }

    }
}
