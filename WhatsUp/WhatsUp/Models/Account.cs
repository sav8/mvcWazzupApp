using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhatsUp.Models
{
    public class Account
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of contact is required")]
        [Display(Name = "Contact Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number of contact is required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address of contact is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Emailaddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    
        public Account()
        {

        }
        public Account(string name, string emailaddress, string password, string phonenumber)
        {
            this.Name = name;
            this.Emailaddress = emailaddress;
            this.Password = password;
            this.PhoneNumber = phonenumber;
        }
       
    }
}