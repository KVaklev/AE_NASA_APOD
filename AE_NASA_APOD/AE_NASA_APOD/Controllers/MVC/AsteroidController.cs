using AE_NASA_APOD.Models;
using BusinessDTOs;
using BusinessExceptions;
using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;

namespace AE_NASA_APOD.Controllers.MVC
{
    public class AsteroidController : Controller
    {
        private readonly IAsteroidService asteroidService;


        public AsteroidController(IAsteroidService asteroidService)
        {
            this.asteroidService = asteroidService;
        }

        [HttpGet]
        public async Task<ActionResult> Index([FromQuery] AsteroidQueryParameters asteroidQueryParameters)
        {
            PaginatedList<Asteroid> asteroids = await asteroidService.FilterBy(asteroidQueryParameters);

            var viewModelItems = asteroids.Select(a => new AsteroidViewModel
            {
                Id = a.Id,
                Name = a.Name,
                NasaJplUrl = a.NasaJplUrl,
                FirstApproachDate = a.CloseApproachData.FirstOrDefault().FirstApproachDate,
                AbsoluteMagnitude = a.AbsoluteMagnitude,
                MaximumDiameter = a.EstimatedDiameter.Kilometers.MaximumDiameter,
                Hazardous = a.Hazardous,
                Velocity = a.CloseApproachData.FirstOrDefault().RelativeVelocity.KilometersPerHour


            }).ToList();

            var viewModel = new PaginatedList<AsteroidViewModel>(viewModelItems, asteroids.TotalPages, asteroids.PageNumber);

            return View(viewModel);
        }
             
        
        [HttpPost]
        public async Task<IActionResult> ExportToXlsx()
        {            
            List<Asteroid> asteroids = await asteroidService.GetAll();

            // Generate the XLSX file
            byte[] fileContents = GenerateXlsxFile(asteroids);

            // Return the XLSX file as a downloadable file
            return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "asteroids.xlsx");
        }

        private byte[] GenerateXlsxFile(List<Asteroid> asteroids)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Asteroids");

                // Add headers
                worksheet.Cells["A1"].Value = "Id";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "NasaJplUrl";
                worksheet.Cells["D1"].Value = "FirstApproachDate";
                worksheet.Cells["E1"].Value = "AbsoluteMagnitude";
                worksheet.Cells["F1"].Value = "MaximumDiameterKm";
                worksheet.Cells["G1"].Value = "Hazardous";
                worksheet.Cells["H1"].Value = "VelocityKmH";



                int row = 2;
                foreach (var asteroid in asteroids)
                {
                    var MaximumDiameter = asteroid.EstimatedDiameter.Kilometers.MaximumDiameter;
                    var FirstApproachDate = asteroid.CloseApproachData.FirstOrDefault()?.FirstApproachDate;
                    var Velocity = asteroid.CloseApproachData.FirstOrDefault().RelativeVelocity.KilometersPerHour;

                    worksheet.Cells[row, 1].Value = asteroid.Id;
                    worksheet.Cells[row, 2].Value = asteroid.Name;
                    worksheet.Cells[row, 3].Value = asteroid.NasaJplUrl;                    
                    worksheet.Cells[row, 4].Value = FirstApproachDate;
                    worksheet.Cells[row, 5].Value = asteroid.AbsoluteMagnitude;
                    worksheet.Cells[row, 6].Value = MaximumDiameter;
                    worksheet.Cells[row, 7].Value = asteroid.Hazardous;
                    worksheet.Cells[row, 8].Value = Velocity;
                    

                    row++;
                }

                return package.GetAsByteArray();
            }
        }
    }
}
