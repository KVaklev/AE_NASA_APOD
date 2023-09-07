using AE_NASA_APOD.ViewModels;
using BusinessQueryParameters;
using BusinessServices.Contracts;
using DataAccessModels.Models;
using DataAccessRepositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AE_NASA_APOD.Controllers.MVC
{
    public class APODController : Controller
    {
        private readonly IAPODService apodService;
        private readonly INasaHttpClientHelper nasaHttpClientHelper;

        public APODController(IAPODService apodService, INasaHttpClientHelper nasaHttpClientHelper)
        {
            this.apodService = apodService;
            this.nasaHttpClientHelper = nasaHttpClientHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] DateTime? date)
        {
            APODViewModel apodViewModel;

            if (date.HasValue)
            {
                var apodResponse = await nasaHttpClientHelper.GetAPODByDate(date);

                if (apodResponse.IsSuccessStatusCode)
                {
                    var apodData = await apodResponse.Content.ReadFromJsonAsync<DataAccessModels.Models.APOD>();

                    apodViewModel = new APODViewModel
                    {
                        Id = apodData.Id,
                        Copyright = apodData.Copyright,
                        Date = apodData.Date,
                        Explanation = apodData.Explanation,
                        HdUrl = apodData.HdUrl,
                        Media_Type = apodData.Media_Type,
                        Service_Version = apodData.Service_Version,
                        Title = apodData.Title,
                        Url = apodData.Url
                    };

                    return View(apodViewModel);
                }
                else
                {
                    // Handle API request failure (e.g., log error, return an error view)
                    return View("Error");
                }
            }
            else
            {
                var apodModel = await apodService.GetPictureOfTheDay();
                apodViewModel = new APODViewModel
                {
                    Id = apodModel.Id,
                    Copyright = apodModel.Copyright,
                    Date = apodModel.Date,
                    Explanation = apodModel.Explanation,
                    HdUrl = apodModel.HdUrl,
                    Media_Type = apodModel.Media_Type,
                    Service_Version = apodModel.Service_Version,
                    Title = apodModel.Title,
                    Url = apodModel.Url
                };
            }

            return View(apodViewModel);
        }

    }
}
