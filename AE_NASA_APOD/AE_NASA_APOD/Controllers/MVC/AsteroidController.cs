using BusinessDTOs;
using BusinessExceptions;
using BusinessQueryParameters;
using BusinessServices.Contracts;
using BusinessViewModels;
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
        public IActionResult Index([FromQuery] AsteroidQueryParameters asteroidQueryParameters)
        {
            List<Asteroid> asteroids = this.asteroidService.FilterBy(asteroidQueryParameters);

            return View(asteroids);
        }

        //public IActionResult Index([FromQuery] AsteroidQueryParameters asteroidQueryParameters)
        //{
        //    List<Asteroid> allAsteroids = this.asteroidService.FilterBy(asteroidQueryParameters);

        //    int pageNumber = asteroidQueryParameters.PageNumber;
        //    int pageSize = asteroidQueryParameters.PageSize;

        //    List<Asteroid> asteroidsOnCurrentPage = allAsteroids
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    var viewModel = new AsteroidViewModel
        //    {
        //        Asteroids = new PaginatedList<Asteroid>(asteroidsOnCurrentPage, pageNumber, pageSize),
        //        QueryParameters = asteroidQueryParameters
        //    };

        //    return View(viewModel);
        //}


        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                Asteroid asteroid = this.asteroidService.GetById(id);

                return View(asteroid);
            }
            catch (EntityNotFoundException e)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = e.Message;

                return this.View("Error");
            }
        }

        [HttpPost]
        public IActionResult ExportToXlsx()
        {            
            List<Asteroid> asteroids = this.asteroidService.GetAll();

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
                worksheet.Cells["B1"].Value = "Title";
                worksheet.Cells["C1"].Value = "Copyright";
                worksheet.Cells["D1"].Value = "Date";
                worksheet.Cells["E1"].Value = "Summary";

                int row = 2;
                foreach (var asteroid in asteroids)
                {
                    worksheet.Cells[row, 1].Value = asteroid.Id;
                    worksheet.Cells[row, 2].Value = asteroid.Title;
                    worksheet.Cells[row, 3].Value = asteroid.Copyright;
                    worksheet.Cells[row, 4].Value = asteroid.DateTime.ToString();
                    worksheet.Cells[row, 5].Value = asteroid.Explanation;
                    row++;
                }

                return package.GetAsByteArray();
            }
        }
    }
}
