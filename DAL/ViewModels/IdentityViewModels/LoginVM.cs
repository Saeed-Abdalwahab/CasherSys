using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.ViewModels.IdentityViewModels
{
public    class LoginVM
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

      
        [Required]

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]

        public bool RememberMe { get; set; }
    }
}
