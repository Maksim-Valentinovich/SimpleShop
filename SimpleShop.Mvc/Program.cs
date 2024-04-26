using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain;
using SimpleShop.Domain.Entities.Clients;
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


            //app.Use(async (context, next) =>
            //{
            //    await next();
            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Request.Path = "/NotFount";
            //        await next();
            //    }
            //});

            //app.Use(async (context, next) =>
            //{
            //    await next.Invoke();
            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Response.Redirect("/NotFound");
            //        await next();
            //    }
            //});

            //обработка ошибок HTTP
            app.UseStatusCodePages(async statusCodeContext =>
            {
                var response = statusCodeContext.HttpContext.Response;
                var path = statusCodeContext.HttpContext.Request.Path;

                response.ContentType = "text/plain; charset=UTF-8";
                if (response.StatusCode == 500)
                {
                    response.Redirect("/ServerError");
                }
                else if (response.StatusCode == 404)
                {
                    response.Redirect("/NotFound");
                }
            });

            
            app.Environment.EnvironmentName = "Production";// состояние продакшн

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
            app.Map("/error",  async (context) =>
            {
                context.Response.Redirect("/ServerError");
            });

            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");
            ////app.Map("/error", (string code) => $"Error Code: {code}");
            //app.Map("/error", async (context) =>
            //{
            //    context.Response.Redirect("/NotFound");
            //});

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