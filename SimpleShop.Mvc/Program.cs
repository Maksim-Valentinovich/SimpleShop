using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clients;
using SimpleShop.Domain.Entities.ShopCards;
using System.Reflection;

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

            builder.Services.AddAutoMapper(typeof(Program), typeof(SimpleShopAppService));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => options.LoginPath = "/account");
            builder.Services.AddAuthorization();

            builder.Services.AddDistributedMemoryCache();// добавил
            builder.Services.AddSession();// добавил

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();// добавил
            builder.Services.AddScoped(sp => ShopCard.GetCard(sp));// добавил
            
            var types = Assembly.GetAssembly(typeof(SimpleShopAppService))!.GetTypes()
                .Where(x => !x.IsAbstract && x.IsClass && typeof(IApplicationService).IsAssignableFrom(x));
            foreach (var type in types)
            {
                builder.Services.AddTransient(type.GetInterface($"I{type.Name}")!, type);
            }

            var app = builder.Build();

            //обработка ошибок HTTP
            //app.UseStatusCodePages(statusCodeContext => {
            //    var response = statusCodeContext.HttpContext.Response;
            //    var path = statusCodeContext.HttpContext.Request.Path;

            //    response.ContentType = "text/plain; charset=UTF-8";
            //    if (response.StatusCode == 500)
            //    {
            //        response.Redirect("/ServerError");
            //    }
            //    else if (response.StatusCode == 404)
            //    {
            //        response.Redirect("/NotFound");
            //    }
            //    return Task.CompletedTask;
            //});


            app.Environment.EnvironmentName = "Production";

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
            app.Map("/error", (context) =>
            {
                context.Response.Redirect("/ServerError");
                return Task.CompletedTask;
            });

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