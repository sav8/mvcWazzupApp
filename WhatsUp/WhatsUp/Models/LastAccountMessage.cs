using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class LastAccountMessage
    {
        public Account OtherAccount { get; set; }
        public string ChatMessage { get; set; }
        public DateTime AddedAt { get; set; }
    }
}