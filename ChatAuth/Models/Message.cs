using System;
using System.ComponentModel.DataAnnotations;

namespace ChatAuth.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(4096, MinimumLength = 1)]
        public string Text { get; set; }
        public DateTime When { get; set; }
        public ChatUser Sender { get; set; }
    }
}
