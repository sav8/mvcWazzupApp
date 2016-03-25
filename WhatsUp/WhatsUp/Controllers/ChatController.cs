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

            IEnumerable<AccountMessage> messages = repository.GetLastMessages(account.Id);
            return View(messages);
        }
        public ActionResult ViewChat(int otherAccountId)
        {
            Account account = (Account)Session["loggedin_account"];
            ViewBag.loggedin = account.Id;
            IEnumerable<AccountMessage> messages = repository.GetAccountMessages(otherAccountId, account.Id);
            return View(messages);
        }

        [HttpPost]
        public ActionResult Send(string message, int otherAccountId)
        {
            Account account = (Account)Session["loggedin_account"];
            repository.SendMessage(message, otherAccountId, account.Id);
            return RedirectToAction("ViewChat");
        }

    }
}
