using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WhatsUp.Models
{
    public class Contact
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ownerAccountId { get; set; }

        public int? whatsupAccountId { get; set; }

        [Required(ErrorMessage = "Name of contact is required")]
        [Display(Name = "Contact Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name of contact is required")]
        [Display(Name = "Contact Phone")]
        public string phoneNumber { get; set; }

        public Contact(int id, string name, string phonenumber)
        {
            this.Id = id;
            this.Name = name;
            this.phoneNumber = phonenumber;
        }
        public Contact()
        {

        }
    } 
}
