using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WhatsUp.Models
{
    public class WhatsUpContext : DbContext
    {
        public WhatsUpContext()
            :base ("WhatsUpConnection")
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Message> Messages { get; set; }

    }
}