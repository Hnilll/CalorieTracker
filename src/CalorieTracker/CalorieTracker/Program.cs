using Microsoft.EntityFrameworkCore;
using CalorieTracker.Data;
using Pomelo.EntityFrameworkCore.MySql;	

namespace CalorieTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {

			var builder = WebApplication.CreateBuilder(args);

			// 1. Získání Connection Stringu ze souboru appsettings.json
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			
			// 2. Registrace AppDbContextu pro MySQL
			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				// Tento zápis vynutí použití správné metody z balíèku Pomelo
				var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
				var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(connectionString);
				options.UseMySql(connectionString, serverVersion);
			});

			// Pøidání služeb pro MVC (Modely, View, Controllery)
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Konfigurace HTTP request pipeline (Middleware)
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles(); // Dùležité pro CSS (Bootstrap) a obrázky

			app.UseRouting();

			app.UseAuthorization();

			// Nastavení routování (jak se mapují URL na Controllery)
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
    }
}
