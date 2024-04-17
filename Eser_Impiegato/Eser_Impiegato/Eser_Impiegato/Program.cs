using Eser_Impiegato.Models;
using Eser_Impiegato.Repositories;
using Eser_Impiegato.Services;
using Microsoft.EntityFrameworkCore;

namespace Eser_Impiegato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<EserImpiegatiContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Locale")
                    )
                );

            builder.Services.AddScoped<ImpiegatoRepo>();
            builder.Services.AddScoped<ImpiegatoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Impiegato}/{action=Lista}/{varMatricola?}");

            app.Run();
        }
    }
}
