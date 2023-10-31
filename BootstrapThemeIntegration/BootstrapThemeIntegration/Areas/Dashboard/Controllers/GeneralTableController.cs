using Microsoft.AspNetCore.Mvc;

namespace BootstrapThemeIntegration.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class GeneralTableController : Controller
    {
        public IActionResult Table()
        {
            return View();
        }
    }
}
