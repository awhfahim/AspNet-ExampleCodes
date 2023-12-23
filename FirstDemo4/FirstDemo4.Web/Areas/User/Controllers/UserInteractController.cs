using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Web.Areas.User.Controllers
{
    [Area("User")]
    public class UserInteractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
