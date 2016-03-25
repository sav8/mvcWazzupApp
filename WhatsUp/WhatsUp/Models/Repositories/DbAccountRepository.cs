using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class DbAccountRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public bool CreateAccount(RegisterModel model)
        {
            if (ctx.Accounts.SingleOrDefault(a => a.Emailaddress == model.EmailAddress) == null &&
                ctx.Accounts.SingleOrDefault(a => a.PhoneNumber == model.MobileNumber) == null)
            {
                Account account = new Account(model.Name, model.EmailAddress, model.Password, model.MobileNumber);
                
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
                Contact contact = ctx.Contacts.SingleOrDefault(c => c.phoneNumber == model.MobileNumber);
                if (contact != null)
                {
                    contact.whatsupAccountId = account.Id;
                    ctx.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public Account GetAccount(string emailaddress, string password)
        {
            Account account = ctx.Accounts.SingleOrDefault(c => (c.Emailaddress == emailaddress) && (c.Password == password));
            return account;
        }
    }
}