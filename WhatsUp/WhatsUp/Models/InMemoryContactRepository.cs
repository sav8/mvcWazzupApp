//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace WhatsUp.Models
//{
//    public class InMemoryContactRepository : IContactRepository
//    {
//        private static List<Contact> allContacts = new List<Contact>();
//        //private List<Group> allGroups = new List<Group>();

        

//        public InMemoryContactRepository()
//        {
//            //allContacts.Add(new Contact(1, "een"));
//            //allContacts.Add(new Contact(2, "twee"));
//            //allContacts.Add(new Contact(3, "drie"));
//        }

//        public IEnumerable<Contact> GetAllContacts()
//        {
//            return allContacts;
//        }
//        public Contact GetContact(int id)
//        {
//            return allContacts.SingleOrDefault(c => c.Id == id);
//        }
//        public void AddContact(Contact contact)
//        {
//            allContacts.Add(contact);
//        }
//        public void UpdateContact(Contact contact)
//        {
//            Contact oudcontact = allContacts.Find(x => x.Id == contact.Id);
//            allContacts.Remove(oudcontact);
//            allContacts.Add(contact);
//        }
//        public void DeleteContact(int id)
//        {
//            Contact contact = allContacts.Find(x => x.Id == id);
//            allContacts.Remove(contact);
//        }
//    }
//}