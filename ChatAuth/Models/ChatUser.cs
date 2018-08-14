using Microsoft.AspNetCore.Identity;

namespace ChatAuth.Models
{
    public class ChatUser : IdentityUser
    {
        [PersonalData]
        public string Alias { get; set; }
    }
}
