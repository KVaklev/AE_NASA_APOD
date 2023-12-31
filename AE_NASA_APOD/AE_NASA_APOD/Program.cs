using BusinessServices.Contracts;
using BusinessServices.Models;
using DataAccessRepositories.Contracts;
using DataAccessRepositories.Helpers;
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

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();

            //Repositories
            builder.Services.AddSingleton<IAsteroidRepository, AsteroidRepository>();
            builder.Services.AddSingleton<IAPODRepository, APODRepository>();

            //Http helper
            builder.Services.AddSingleton<INasaHttpClientHelper, NasaHttpClientHelper>();

            //Services
            builder.Services.AddScoped<IAsteroidService, AsteroidService>();
            builder.Services.AddScoped<IAPODService, APODService>();
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