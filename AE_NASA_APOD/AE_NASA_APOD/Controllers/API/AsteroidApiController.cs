using BusinessExceptions;
using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using Mapper;
using Microsoft.AspNetCore.Mvc;

namespace AE_NASA_APOD.Controllers.API
{
    [ApiController]
    [Route("api/asteroid")]
    public class AsteroidApiController : ControllerBase
    {
        private readonly IAsteroidService asteroidService;
        private readonly ModelMapper modelMapper;

        public AsteroidApiController(IAsteroidService asteroidService, ModelMapper modelMapper)
        {
            this.asteroidService = asteroidService;
        }

        [HttpGet("")]
        public IActionResult GetAsteroids([FromQuery] AsteroidQueryParameters queryParameters)
        {
            List<Asteroid> result = this.asteroidService.FilterBy(queryParameters);

            return this.StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("{id}")]

        public IActionResult GetAsteroidById(int id)
        {
            try
            {
                Asteroid asteroid = this.asteroidService.GetById(id);

                return this.StatusCode(StatusCodes.Status200OK, asteroid);

            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}
