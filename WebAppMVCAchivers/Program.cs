using Microsoft.EntityFrameworkCore;
using WebAppMVCAchivers.Models;

namespace WebAppMVCAchivers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            Rectangle rect = new Square();
            rect.Width = 5;
            rect.Height = 10;

            Console.WriteLine(rect.Area()); // Expected: 50


            builder.Services.AddDbContext<MyProjectLibrary.Models.AppDb>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<MyProjectLibrary.Interfaces.IUsers, MyProjectLibrary.BusinessLogic.UserBl>();
            builder.Services.AddScoped<MyProjectLibrary.Interfaces.IMovies, MyProjectLibrary.BusinessLogic.MoviesBl>();
            builder.Services.AddScoped<MyProjectLibrary.Interfaces.IAadhar, MyProjectLibrary.BusinessLogic.AadharBl>();
            builder.Services.AddScoped<MyProjectLibrary.Interfaces.ICountry, MyProjectLibrary.BusinessLogic.CountryBl>();
            builder.Services.AddScoped<MyProjectLibrary.Interfaces.IUsersSp, MyProjectLibrary.BusinessLogic.UserblSp>();

            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(60);
                option.Cookie.IsEssential = true;
            });
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // evelopment environment error page  

            }
            else if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Authenticate}/{id?}");

            app.Run();
        }
    }
}
