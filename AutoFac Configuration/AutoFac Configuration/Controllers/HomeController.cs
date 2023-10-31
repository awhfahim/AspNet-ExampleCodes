using AutoFac_Configuration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoFac_Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailUtility _emailUtility;

        public HomeController(ILogger<HomeController> logger, IEmailUtility emailUtility)
        {
            _logger = logger;
            _emailUtility = emailUtility;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("I am at index");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation($"{nameof(Privacy)}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}