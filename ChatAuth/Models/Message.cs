using System;

namespace ChatAuth.Models
{
    public class Message
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public string Text { set; get; }
        public DateTime When { set; get; }
    }
}
