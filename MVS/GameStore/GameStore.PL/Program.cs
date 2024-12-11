using GameStore.BL.Services.Implementations;
using GameStore.BL.Services.Interfaces;
using GameStore.DAL.DAL;
using GameStore.DAL.Implementations;
using GameStore.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
