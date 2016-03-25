using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        // GET: /Chat/
        private DbChatRepository repository = new DbChatRepository();

        public ActionResult Index()
        {
            Account account = (Account)Session["loggedin_account"];
            if (account != null)
            {
                IEnumerable<AccountMessage> messages = repository.GetLastMessages(account.Id);
                return View(messages);
            }
            return RedirectToAction("LogOut", "Account");
        }
        public ActionResult ViewChat(int otherAccountId)
        {
            Account account = (Account)Session["loggedin_account"];
            if (account != null)
            {
                ViewBag.loggedin = account.Id;
                ViewBag.contactname = repository.GetContactName(account.Id, otherAccountId);
                IEnumerable<AccountMessage> messages = repository.GetAccountMessages(otherAccountId, account.Id);
                if (messages.Count() == 0)
                {
                    repository.SendMessage("Welkom, er zijn nog geen chatberichten.", otherAccountId, account.Id);
                    return RedirectToAction("ViewChat", "Chat", new { otherAccountId = otherAccountId });
                }
                return View(messages);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult Send(string message, int otherAccountId)
        {
            Account account = (Account)Session["loggedin_account"];
            repository.SendMessage(message, otherAccountId, account.Id);
            return RedirectToAction("ViewChat", "Chat", new { otherAccountId = otherAccountId });
        }

    }
}
