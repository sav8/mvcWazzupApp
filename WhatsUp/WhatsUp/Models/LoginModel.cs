using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhatsUp.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email Address")]
        public string Emailaddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}