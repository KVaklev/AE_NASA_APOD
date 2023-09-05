using BusinessServices.Contracts;
using BusinessServices.Models;
using DataAccessRepositories.Contracts;
using DataAccessRepositories.Models;
using Mapper;
using OfficeOpenXml;

namespace AE_NASA_APOD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            
            app.Run();
        }
    }
}