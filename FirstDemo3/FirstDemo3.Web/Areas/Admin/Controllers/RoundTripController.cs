using Microsoft.AspNetCore.Mvc;
using FirstDemo3.Web.Areas.Admin.Models;
using Autofac;

namespace FirstDemo3.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RoundTripController : Controller
    {      
        private ILifetimeScope _scope;
        private ILogger<RoundTripController> _logger;

        public RoundTripController(ILifetimeScope scope, ILogger<RoundTripController> logger)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Create()
        {
            var model = new RoundTrip();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(RoundTrip roundTrip)
        {
            if(ModelState.IsValid)
            {
                roundTrip.Resolve(_scope);
                roundTrip.SearchTrip();
                return RedirectToAction("Create");
            }
            return View();
        }
    }
}
