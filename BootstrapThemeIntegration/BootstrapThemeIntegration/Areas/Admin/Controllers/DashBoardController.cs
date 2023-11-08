using Microsoft.AspNetCore.Mvc;

namespace BootstrapThemeIntegration.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        public IActionResult AdminLteIndex()
        {
            return View();
        }

        public IActionResult TopNav()
        {
            return View();
        }
    }
}
