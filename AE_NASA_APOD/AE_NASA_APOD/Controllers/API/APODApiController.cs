using BusinessDTOs;
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
        public async Task<IActionResult> GetTodayAPOD()
        {
            DateTime today = DateTime.UtcNow.Date; 

            try
            {
                APOD apod = await this.apodService.GetAPODByDate(today);

                if (apod == null)
                {
                    return NotFound(); 
                }

                GetAPODDTO getAPODDTO = mapper.Map(apod);

                return Ok(getAPODDTO);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching today's APOD.");
            }
        }



    }
}
