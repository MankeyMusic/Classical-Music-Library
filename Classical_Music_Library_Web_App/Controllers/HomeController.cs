using Microsoft.AspNetCore.Mvc;

namespace Classical_Music_Library_Web_App.Controllers
{
    // Handles the homepage and basic navigation
    public class HomeController : Controller
    {
        // GET: /Home/Index
        public IActionResult Index()
        {
            return View(); // Renders Views/Home/Index.cshtml
        }
    }
}