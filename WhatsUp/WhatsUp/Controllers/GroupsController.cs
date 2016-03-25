using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        //
        // GET: /Groups/
        private DbGroupRepository repository = new DbGroupRepository();
        public ActionResult Index()
        {

            Account account = (Account)Session["loggedin_account"];
            if (account != null)
            {
                IEnumerable<Group> groups = repository.GetGroups(account.Id);
                return View(groups);
            }
            return RedirectToAction("LogOut", "Account");
        }
        public ActionResult ViewChat(int groupid)
        {
            Account account = (Account)Session["loggedin_account"];
            if (account != null)
            {
                ViewBag.accountid = account.Id;
                ViewBag.groupid = groupid;
                IEnumerable<GroupMessageModel> groupMessages = repository.GetGroupMessages(groupid);
                List<Account> accounts = new List<Account>();
                foreach (GroupMessageModel a in groupMessages)
                {
                    if(!accounts.Contains(a.Participant))
                    {
                        accounts.Add(a.Participant);
                    }
                }
                ViewBag.Participants = accounts;   
                return View(groupMessages);
            }
            return RedirectToAction("LogOut", "Account");
        }
        [HttpPost]
        public ActionResult Send(string message, int groupId)
        {
            Account account = (Account)Session["loggedin_account"];
            repository.SendMessage(message, groupId, account.Id);
            return RedirectToAction("ViewChat", "Groups", new { groupid = groupId });
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string name)
        {
            Account account = (Account)Session["loggedin_account"];
            repository.CreateGroup(name, account.Id);
            return RedirectToAction("index", "Contacts");
        }
        public ActionResult Add(int groupId)
        {
            ViewBag.groupId = groupId;
            Account account = (Account)Session["loggedin_account"];
            IEnumerable<Contact> contacts = repository.GetContacts(account.Id);
            return View(contacts);
        }
        [HttpPost]
        public ActionResult Add(int accountId, int groupId)
        {
            repository.AddAccountToGroup(accountId, groupId);
            return RedirectToAction("index", "Groups");
        }
    }
}
