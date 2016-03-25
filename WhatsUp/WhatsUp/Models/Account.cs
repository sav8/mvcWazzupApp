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
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address of contact is required")]
        [Display(Name = "Email Address")]
        public string Emailaddress { get; set; }

        public string Password { get; set; }

        public Account(int id, string name, string phonenumber, string emailaddress, string password)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phonenumber;
            this.Emailaddress = emailaddress;
            this.Password = password;
        }
        public Account()
        {

        }
    }
}