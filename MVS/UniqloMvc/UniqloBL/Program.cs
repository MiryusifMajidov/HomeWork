using Microsoft.EntityFrameworkCore;
using UniqloBT.Service.Implementations;
using UniqloBT.Service.Interface;
using UniqloDAL.DAL;
using UniqloDAL.Implementations;
using UniqloDAL.Interfaces;

namespace UniqloBL
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

            app.UseRouting();

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
