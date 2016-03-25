using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class GroupMessageModel
    {
        public string Name { get; set; }
        public GroupMessage Message { get; set; }

        public Account Participant { get; set; }

        public DateTime DateTime { get; set; }

        public GroupMessageModel()
        {

        }
    }
}