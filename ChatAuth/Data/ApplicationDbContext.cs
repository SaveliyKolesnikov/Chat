using ChatAuth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext<ChatUser>
    {
        public DbSet<Message> Messages { set; get; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ChatUser>()
                .Property(u => u.Alias)
                .HasField("_alias");
            base.OnModelCreating(builder);
        }
    }
}
