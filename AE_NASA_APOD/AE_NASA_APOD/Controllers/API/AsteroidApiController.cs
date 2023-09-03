using BusinessServices.Contracts;
using DataAccessModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace AE_NASA_APOD.Controllers.API
{
    [ApiController]
    [Route("api/asteroid")]
    public class AsteroidApiController : ControllerBase
    {
        private readonly IAsteroidService asteroidService;

        public AsteroidApiController(IAsteroidService asteroidService)
        {
            this.asteroidService = asteroidService;
        }

        [HttpGet("")]
        public IActionResult GetAsteroids([FromQuery] AsteroidQueryParameters queryParameters)
        {
            List<Asteroid> result = this.asteroidService.GetAll();

            return this.StatusCode(StatusCodes.Status200OK, result);
        }

        //[HttpGet("{id}")]

        //public IActionResult GetAsteroidById(int id)
        //{

        //}


    }
}
