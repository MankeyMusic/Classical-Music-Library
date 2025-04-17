using System.Diagnostics;
using Classical_Music_Library_Web_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classical_Music_Library_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MusicDbContext _context;

        // Correct constructor with dependency injection
        public HomeController(ILogger<HomeController> logger, MusicDbContext context)
        {
            _logger = logger;
            _context = context; // Now properly injected
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Now using ErrorViewModel correctly
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}