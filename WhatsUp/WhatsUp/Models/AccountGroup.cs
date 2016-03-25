using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhatsUp.Models
{
    public class AccountGroup
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public AccountGroup()
        {

        }
    }
}