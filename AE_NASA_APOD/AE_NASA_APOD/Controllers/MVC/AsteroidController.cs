using BusinessExceptions;
using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

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
    }
}
