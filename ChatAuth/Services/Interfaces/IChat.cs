using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAuth.Models
{
    public interface IChat
    {
        Task AddMessageAsync(Message message);
        Task DeleteMessageAsync(Message message);
        IQueryable<Message> GetMessagesesAsync();
    }
}
