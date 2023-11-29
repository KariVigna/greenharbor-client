using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GreenHarborClient.Models;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.UseAuthorization();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}
namespace GreenHarborClient 
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        // be sure to update the line below for your project
        // builder.Services.AddDbContext<ToDoListContext>(
        //                 dbContextOptions => dbContextOptions
        //                 .UseMySql(
        //                     builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
        //                 )
        //             )
        //         );

      // Line below adds Identity
    builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                // .AddEntityFrameworkStores<ToDoListContext>()
                .AddDefaultTokenProviders();

      // This is where we can determine Password requirements for users.
    builder.Services.Configure<IdentityOptions>(options =>
        {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
        });

        WebApplication app = builder.Build();

    app.UseDeveloperExceptionPage();
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

      // Next two lines below enable authentication and authorization.
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );

    app.Run();
        }
    }
}