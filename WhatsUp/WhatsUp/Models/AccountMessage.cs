using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class AccountMessage
    {
        public int SenderAccount { get; set; }
        public Account OtherAccount { get; set; }
        public DateTime AddedAt { get; set; }
        public string Message { get; set; }
    }
}