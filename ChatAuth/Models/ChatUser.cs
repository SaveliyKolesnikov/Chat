using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ChatAuth.Models
{
    public class ChatUser : IdentityUser
    {
        private string _alias;

        [PersonalData]
        [StringLength(24, MinimumLength = 1)]
        public string Alias
        {
            get => _alias ?? UserName ?? "Anonymous";
            set => _alias = value;
        }
    }
}
