using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;  //include this to capture the reference [Required]

namespace tFX_tool.ViewModel
{
    public class Register
    {
        [Required]
        [Display(Name = "Names")]
        public string Names { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        //we will use reguslar expression to check if email is valid lie for tobi@test.com
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@(a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }      

    }
}