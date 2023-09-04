using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace AE_NASA_APOD.Controllers.MVC
{
    public class AsteroidController : Controller
    {
        private readonly IAsteroidService asteroidService;


        public AsteroidController (IAsteroidService asteroidService)
        {
            this.asteroidService = asteroidService;
        }

        [HttpGet]
        public IActionResult Index(AsteroidQueryParameters asteroidQueryParameters)
        {
            List<Asteroid> asteroids = this.asteroidService.FilterBy(asteroidQueryParameters);

            return View(asteroids);
        }
    }
}
