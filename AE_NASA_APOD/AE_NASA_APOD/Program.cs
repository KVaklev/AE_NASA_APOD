using BusinessServices.Contracts;
using BusinessServices.Models;
using DataAccessRepositories.Contracts;
using DataAccessRepositories.Models;
using Mapper;

namespace AE_NASA_APOD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<ApplicationContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //    options.EnableSensitiveDataLogging();
            //});

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();

            //Repositories
            builder.Services.AddSingleton<IAsteroidRepository, AsteroidRepository>();

            //Services
            builder.Services.AddScoped<IAsteroidService, AsteroidService>();
            builder.Services.AddScoped<ModelMapper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}