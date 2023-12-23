using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Web.Areas.User.Controllers
{
    [Area("User")]
    public class ExpenseController : Controller
    {
        public IActionResult AddExpense()
        {
            return View();
        }
    }
}
