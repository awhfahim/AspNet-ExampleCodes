using Microsoft.AspNetCore.Mvc;
using TicketResevation.Areas.Booking.Models;

namespace TicketResevation.Areas.Booking.Controllers
{
	public class NavController : Controller
	{
		[Area("Booking")]
		public IActionResult Index()
		{
			var model = new Input();
			return View(model);
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Index(Input input)
		{
			return View(input);
		}
	}
}
