using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherWA.Models;
using WeatherWA.Services;

namespace WeatherWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync(string CityName="Baku")
        {
                WeatherService weatherService = new WeatherService();
                var result = await weatherService.Search(CityName);
                return View(result);
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
