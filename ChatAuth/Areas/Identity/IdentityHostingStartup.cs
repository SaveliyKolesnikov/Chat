using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ChatAuth.Areas.Identity.IdentityHostingStartup))]
namespace ChatAuth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}