using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.ShopCards;

namespace SimpleShop.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>()).AddControllersWithViews().AddRazorRuntimeCompilation();

            string? connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<SimpleShopContext>(x => x.UseNpgsql(connectionString));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); 

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => options.LoginPath = "/account");
            builder.Services.AddAuthorization();

            builder.Services.AddDistributedMemoryCache();// добавил
            builder.Services.AddSession();// добавил

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// добавил
            builder.Services.AddScoped(sp => ShopCard.GetCard(sp));// добавил


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseResponseCompression();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();// добавил

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "PersonalAccount",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}