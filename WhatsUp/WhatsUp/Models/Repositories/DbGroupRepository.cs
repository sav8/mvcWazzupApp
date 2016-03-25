using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class DbGroupRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public IEnumerable<Group> GetGroups(int accountid)
        {
            List<Group> groups = new List<Group>();
            IEnumerable<AccountGroup> accountGroup = ctx.AccountGroup.Where(a => a.AccountId == accountid);
            foreach (AccountGroup a in accountGroup)
            {
                Group group = ctx.Groups.SingleOrDefault(g => g.Id == a.GroupId);
                groups.Add(group);
            }
            return (IEnumerable<Group>)groups;
        }
        public IEnumerable<GroupMessageModel> GetGroupMessages(int groupid)
        {
            Group group = ctx.Groups.SingleOrDefault(g => g.Id == groupid);
            IEnumerable<AccountGroup> accountGroup = ctx.AccountGroup.Where(a => a.GroupId == groupid);
            IEnumerable<GroupMessage> groupMessages = ctx.GroupMessages.Where(m => m.Groupid == groupid);

            List<GroupMessageModel> groupMessageModels = new List<GroupMessageModel>();
            
            foreach(GroupMessage message in groupMessages)
            {
                GroupMessageModel groupMessageModel = new GroupMessageModel();
                groupMessageModel.Message = message;
                groupMessageModel.DateTime = message.DateTime;
                groupMessageModel.Name = group.Name;

                Account account = ctx.Accounts.SingleOrDefault(c => c.Id == message.AccountId);
                groupMessageModel.Participant = account;

                groupMessageModels.Add(groupMessageModel);
            }
            return (IEnumerable<GroupMessageModel>)groupMessageModels;
        }
        public IEnumerable<Contact> GetContacts(int accountid)
        {
            IEnumerable<Contact> contacts = ctx.Contacts.Where(c => c.ownerAccountId == accountid);
            return contacts;
        }
        public void SendMessage(string message, int groupId, int accountid)
        {
            GroupMessage groupMessage = new GroupMessage(accountid, DateTime.Now, groupId, message);
            ctx.GroupMessages.Add(groupMessage);
            ctx.SaveChanges();
        }
        public void AddAccountToGroup(int accountid, int groupid)
        {
            AccountGroup accountgroup = new AccountGroup();
            accountgroup.AccountId = accountid;
            accountgroup.GroupId = groupid;
            ctx.AccountGroup.Add(accountgroup);
            ctx.SaveChanges();
        }
        public void CreateGroup(string name, int accountid)
        {
            Group group = new Group();
            group.Name = name;
            ctx.Groups.Add(group);
            ctx.SaveChanges();
            AccountGroup accountGroup = new AccountGroup();
            accountGroup.AccountId = accountid;
            accountGroup.GroupId = group.Id;
            ctx.AccountGroup.Add(accountGroup);
            ctx.SaveChanges();
        }
    }
}