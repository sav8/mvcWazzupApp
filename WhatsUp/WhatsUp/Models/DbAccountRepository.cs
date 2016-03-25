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
                Account account = new Account();
                account.Name = model.Name;
                account.Emailaddress = model.EmailAddress;
                account.Password = model.Password;
                account.PhoneNumber = model.MobileNumber;
                
                ctx.Accounts.Add(account);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public Account GetAccount(string emailaddress, string password)
        {
            return ctx.Accounts.Single(c => (c.Emailaddress == emailaddress) && (c.Password == password));
        }
    }
}