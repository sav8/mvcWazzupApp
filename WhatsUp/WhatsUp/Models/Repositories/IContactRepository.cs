using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();
        IEnumerable<Contact> GetContactsForUser(int ownerAccountId);
        Contact GetContact(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
    }
}