using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatAuth.Models
{
    public interface IChat
    {
        Task AddMessageAsync(Message message);
        Task DeleteMessageAsync(Message message);
        IEnumerable<Message> GetMessagesesAsync();
    }
}
