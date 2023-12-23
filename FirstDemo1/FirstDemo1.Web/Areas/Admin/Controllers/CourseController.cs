using Autofac;
using FirstDemo.Infrastructure;
using FirstDemo1.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDemo1.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILifetimeScope scope, ILogger<CourseController> logger)
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
            model.Title = "Asp.net";
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
            return View();
        }

        public async Task<JsonResult> GetCourses()
        {
            var dataTablesModel = new DataTablesAjaxRequestUtility(Request);
            var model = _scope.Resolve<CourseListModel>();

            var data = await model.GetPagedCoursesAsync(dataTablesModel);
            return Json(data);
        }

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(Guid id)
		{
			var model = _scope.Resolve<CourseListModel>();

			if (ModelState.IsValid)
			{
				try
				{
					await model.DeleteCourseAsync(id); 

					return RedirectToAction("Index");
				}
				catch (Exception e)
				{
					_logger.LogError(e, "Server Error");
				}
			}

			return RedirectToAction("Index");
		}
	}
}
