using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class DbContactRepository : IContactRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public IEnumerable<Contact> GetContactsForUser(int ownerAccountId)
        {
            IEnumerable<Contact> contacts = ctx.Contacts.Where(c => c.ownerAccountId == ownerAccountId);
            return contacts;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            IEnumerable<Contact> allContacts = ctx.Contacts;
            return allContacts;
        }

        public Contact GetContact(int id)
        {
            return ctx.Contacts.SingleOrDefault(c => c.Id == id);
        }
        public void AddContact(Contact contact)
        {
            Account account = ctx.Accounts.SingleOrDefault(c => c.PhoneNumber == contact.phoneNumber);
            if (account == null)
            {
                ctx.Contacts.Add(contact);
                ctx.SaveChanges();
                return;
            }
            contact.whatsupAccountId = account.Id;
            ctx.Contacts.Add(contact);
            ctx.SaveChanges();
        }
        public void UpdateContact(Contact contact)
        {
            Contact oudcontact = ctx.Contacts.SingleOrDefault(c => c.Id == contact.Id);
            oudcontact.Name = contact.Name;
            ctx.SaveChanges();
        }
        public void DeleteContact(int id)
        {
            Contact contact = ctx.Contacts.SingleOrDefault(c => c.Id == id);
            ctx.Contacts.Remove(contact);
            ctx.SaveChanges();
        }
    }
}