using System;

namespace ChatAuth.Models
{
    public interface IMessage
    {
        string UserName { get; set; }
        string Text { get; set; }
        DateTime When { get; set; }
        ChatUser Sender { get; set; }
    }
}