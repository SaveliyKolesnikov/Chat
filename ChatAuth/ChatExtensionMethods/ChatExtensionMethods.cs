using ChatAuth.Data;
using ChatAuth.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ChatAuth.ChatExtensionMethods
{
    public static class ChatExtensionMethods
    {
        public static void AddChat(this IServiceCollection service, ApplicationDbContext db)
        {
            service.AddSingleton<IChat, Chat>(s => new Chat(db));
        }
    }
}