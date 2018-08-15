using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ChatAuth.Models
{
    public class ChatUser : IdentityUser
    {
        [PersonalData]
        [StringLength(24, MinimumLength = 1)]
        public string Alias { get; set; }
    }
}
