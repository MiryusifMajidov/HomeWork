using InanceBL.Services;
using InanceBL.Services.Implementations;
using InanceBL.Services.Interfaces;
using InanceDAL.DAL;
using InanceDAL.Implementations;
using InanceDAL.Interfaces;
using InanceModels.Models;
using Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Inance.PL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();

            builder.Services.Configure<SmtpSetting>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.AddScoped<EmailService>();




            builder.Services.AddIdentity<AppUser, IdentityRole>(
				opt =>
				{
					opt.Password.RequiredLength = 3;
					opt.User.RequireUniqueEmail = true;
				}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

			builder.Services.AddDbContext<AppDbContext>(options => 
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                await RoleSeeder.SeedRoles(serviceProvider);
            }



            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();



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
