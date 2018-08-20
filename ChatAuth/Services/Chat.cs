using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ChatAuth.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatAuth.Models
{
    public class Chat : IChat
    {
        private readonly ApplicationDbContext _db;

        public Chat(ApplicationDbContext db) => _db = db;

        public async Task AddMessageAsync(Message message)
        {
            await _db.Messages.AddAsync(message);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }

        public void SendMessageAsync(Message message)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Message> GetMessagesesAsync() =>  
            _db.Messages.Include(m => m.Sender);

        public Task DeleteMessageAsync(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}