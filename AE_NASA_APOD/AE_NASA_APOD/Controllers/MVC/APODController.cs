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
        public IActionResult Index([FromQuery] APODQueryParameters apodQueryParameters)
        {
            List<APOD> apods = this.apodService.FilterBy(apodQueryParameters);  

            return View(apods);
        }
    }
}
