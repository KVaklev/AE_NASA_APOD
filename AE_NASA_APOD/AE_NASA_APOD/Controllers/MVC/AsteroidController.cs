using Microsoft.AspNetCore.Mvc;

namespace AE_NASA_APOD.Controllers.MVC
{
    public class AsteroidController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
