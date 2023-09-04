using Microsoft.AspNetCore.Mvc;

namespace AE_NASA_APOD.Controllers.MVC
{
    public class HomeController : Controller
    {
        [HttpGet]   
        public IActionResult Index()
        {
            return View();
        }
    }
}
