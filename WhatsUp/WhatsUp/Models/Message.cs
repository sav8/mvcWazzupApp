using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhatsUp.Models
{
    public class Message
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ReceiverId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public string ChatMessage { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        public Message()
        {
            
        }
    }
}