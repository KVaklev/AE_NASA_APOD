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
        public IActionResult Index()
        {
            List<Asteroid> asteroids = this.asteroidService.GetAll();

            return View(asteroids);
        }
    }
}
