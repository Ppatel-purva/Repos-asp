using LoggerMvcCounter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggerMvcCounter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        int counter = 0;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.Log(LogLevel.Information, "Visited" + counter++ + "time");
            ViewBag.Message = counter;
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}