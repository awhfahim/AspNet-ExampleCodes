using BootstrapThemeIntegration.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootstrapThemeIntegration.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(UserDetails userDetails)
        {
            return View(userDetails);
        }
    }
}
