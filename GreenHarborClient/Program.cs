using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GreenHarborClient.Models;

namespace GreenHarborClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure DbContext with MySQL
            builder.Services.AddDbContext<GreenHarborClientContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"), 
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
                )
            );

            // Add Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GreenHarborClientContext>()
                .AddDefaultTokenProviders();

            // Configure Identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            // Add API client configuration
            // Replace this with your actual API client configuration
            // builder.Services.AddHttpClient("GreenHarborClient", client =>
            // {
            //     client.BaseAddress = new Uri("https://your-api-base-url.com");
            //     // Add any additional configuration for your API client
            // });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
