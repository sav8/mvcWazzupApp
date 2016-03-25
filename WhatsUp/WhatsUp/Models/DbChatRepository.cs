using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class DbChatRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public IEnumerable<AccountMessage> GetLastMessages(int accountId)
        {
            List<int> includedAccounts = new List<int>();
            List<AccountMessage> messagesReturn = new List<AccountMessage>();
            IEnumerable<Message> messages = ctx.Messages.Where(m => m.SenderId == accountId || m.ReceiverId == accountId).OrderByDescending(m => m.DateTime);
            foreach (Message m in messages)
            {
                AccountMessage message = new AccountMessage();
                message.AddedAt = m.DateTime;
                message.Message = m.ChatMessage;     

                if (m.SenderId == accountId && !includedAccounts.Contains(m.ReceiverId))
                {
                    message.OtherAccount = ctx.Accounts.Single(a => a.Id == m.ReceiverId);
                    includedAccounts.Add(m.ReceiverId);
                    messagesReturn.Add(message);
                }
                else if(m.ReceiverId == accountId && !includedAccounts.Contains(m.SenderId))
                {
                    message.OtherAccount = ctx.Accounts.Single(a => a.Id == m.SenderId);
                    includedAccounts.Add(m.SenderId);
                    messagesReturn.Add(message);
                }
            }
            return (IEnumerable<AccountMessage>)messagesReturn;
        }
        public IEnumerable<AccountMessage> GetAccountMessages(int otherAccountId, int accountId)
        {
            List<AccountMessage> messagesReturn = new List<AccountMessage>();
            IEnumerable<Message> messages = ctx.Messages.Where(m => (m.SenderId == accountId && m.ReceiverId == otherAccountId) || (m.SenderId == otherAccountId && m.ReceiverId == accountId));
            List<AccountMessage> accountMessages = new List<AccountMessage>();
            foreach (Message m in messages)
            {
                AccountMessage message = new AccountMessage();
                message.AddedAt = m.DateTime;
                message.Message = m.ChatMessage;

                if (m.SenderId == accountId)
                {
                    message.OtherAccount = ctx.Accounts.Single(a => a.Id == m.ReceiverId);
                    message.SenderAccount = accountId;
                    messagesReturn.Add(message);
                }
                else if (m.ReceiverId == accountId)
                {
                    message.OtherAccount = ctx.Accounts.Single(a => a.Id == m.SenderId);
                    message.SenderAccount = message.OtherAccount.Id;
                    messagesReturn.Add(message);
                }

                accountMessages.Add(message);
            }

            return (IEnumerable<AccountMessage>)accountMessages.OrderBy(m => m.AddedAt);
        }

        public void SendMessage(string message, int otherAccountId, int accountId)
        {
            Message chatMessage = new Message();
            chatMessage.ChatMessage = message;
            chatMessage.DateTime = DateTime.Now;
            chatMessage.ReceiverId = otherAccountId;
            chatMessage.SenderId = accountId;

            ctx.Messages.Add(chatMessage);
            ctx.SaveChanges();
        }
    }
}