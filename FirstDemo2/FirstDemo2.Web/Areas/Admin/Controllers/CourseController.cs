using Autofac;
using FirstDemo2.Application;
using FirstDemo2.Domain.Features.Training;
using FirstDemo2.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using FirstDemo2.Web.Areas.Admin.Models;

namespace FirstDemo.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CourseController : Controller
	{
		private readonly ILifetimeScope _scope;
		private readonly ILogger<CourseController> _logger;

		public CourseController(ILifetimeScope scope, 
			ILogger<CourseController> logger)
		{
			_scope = scope;
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();           
		}
		
		public IActionResult Create()
		{
			var model = _scope.Resolve<CourseCreateModel>();
            return View(model);
        }

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Create(CourseCreateModel model)
		{
			if(ModelState.IsValid)
			{
				model.Resolve(_scope);
				model.CreateCourse();
				return RedirectToAction("Index");
			}

			return View(model);
		}
	}
}
