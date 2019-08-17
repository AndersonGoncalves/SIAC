using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiacWeb.Models;

[assembly: HostingStartup(typeof(SiacWeb.Areas.Identity.IdentityHostingStartup))]
namespace SiacWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<SiacWebIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SiacWebContext")));

                services.AddDefaultIdentity<IdentityUser>()
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<SiacWebIdentityContext>();
            });
        }
    }
}