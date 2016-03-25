using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhatsUp.Models
{
    public class GroupMessage
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Groupid { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int AccountId { get; set; }

        public GroupMessage()
        {

        }

        public GroupMessage(int accountId, DateTime dateTime, int groupId, string message)
        {
            this.AccountId = accountId;
            this.DateTime = dateTime;
            this.Groupid = groupId;
            this.Message = message;
        }
    }
}