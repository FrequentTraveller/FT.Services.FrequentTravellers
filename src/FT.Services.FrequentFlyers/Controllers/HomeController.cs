using Microsoft.AspNetCore.Mvc;

namespace FT.Services.FrequentFlyers.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Ok("Distribued Frequent Flyer Service");
    }
}