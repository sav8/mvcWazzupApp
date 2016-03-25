using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private IContactRepository contactRepository = new DbContactRepository();

        // GET: /Contacts/
        public ActionResult Index()
        {
            Account account = (Account)Session["loggedin_account"];
            IEnumerable<Contact> allContacts = contactRepository.GetContactsForUser(account.Id);
            return View(allContacts);
        }
        public ActionResult Update(int id)
        {
            Contact contact = contactRepository.GetContact(id);
            return View(contact);//contact meegeven
        }
        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            contactRepository.UpdateContact(contact);
            return RedirectToAction("index");
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Account account = (Account)Session["loggedin_account"];
                contact.ownerAccountId = account.Id;
                contactRepository.AddContact(contact);
                return RedirectToAction("index");
            }
            //error, go back
            return View(contact);
        }
        public ActionResult Delete(int id)
        {
            contactRepository.DeleteContact(id);
            return RedirectToAction("index");
        }
    }
}
