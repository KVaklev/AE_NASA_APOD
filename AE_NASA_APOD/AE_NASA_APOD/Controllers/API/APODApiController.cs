using BusinessDTOs;
using BusinessExceptions;
using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using Mapper;
using Microsoft.AspNetCore.Mvc;

namespace AE_NASA_APOD.Controllers.API
{
    [ApiController]
    [Route("api/apod")]
    public class APODApiController : ControllerBase
    {
        private readonly IAPODService apodService;
        private readonly ModelMapper mapper;

        public APODApiController(IAPODService apodService, ModelMapper mapper)
        {
            this.apodService = apodService;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetAPODs([FromQuery] APODQueryParameters queryParameters)
        {
            List<APOD> result = this.apodService.FilterBy(queryParameters);

            List<GetAPODDTO> getAPODDTOs = result.Select(apod => mapper.Map(apod)).ToList();

            return this.StatusCode(StatusCodes.Status200OK, getAPODDTOs);
        }

        [HttpGet("{id}")]

        public IActionResult GetApodById(int id)
        {
            try
            {
                APOD apod = this.apodService.GetById(id);

                GetAPODDTO getAPODDTO = mapper.Map(apod);

                return this.StatusCode(StatusCodes.Status200OK, getAPODDTO);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

    }
}
