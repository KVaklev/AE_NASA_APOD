using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace AE_NASA_APOD.Controllers.MVC
{
    public class APODController : Controller
    {
        private readonly IAPODService apodService;

        public APODController(IAPODService apodService)
        {
            this.apodService = apodService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] APODQueryParameters apodQueryParameters)
        {
            List<APOD> apods = await this.apodService.FilterBy(apodQueryParameters);  

            return View(apods);
        }
    }
}
