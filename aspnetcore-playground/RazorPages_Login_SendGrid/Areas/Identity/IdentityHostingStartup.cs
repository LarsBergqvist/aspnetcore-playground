using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(RazorPages_Login_SendGrid.Areas.Identity.IdentityHostingStartup))]
namespace RazorPages_Login_SendGrid.Areas.Identity
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