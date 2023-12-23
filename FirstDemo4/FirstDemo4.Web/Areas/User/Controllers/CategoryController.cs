using Autofac;
using ExpenseTracker.Web.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExpenseTracker.Web.Areas.User.Controllers
{
	[Area("User")]
	public class CategoryController : Controller
	{
		private ILogger<CategoryController> _logger;
		private ILifetimeScope _scope;
		public CategoryController(ILogger<CategoryController> logger, ILifetimeScope scope)
			=> (_logger,_scope) = (logger, scope);
		public IActionResult AddCategory()
		{
			var model = new AddCategoryModel();
			return View(model);
		}

		public async Task<IActionResult> AddCategory(AddCategoryModel model)
		{
			if (ModelState.IsValid)
			{
				model.Resolve(_scope);
				await model.AddCategoryTask(model);
				return RedirectToAction("AddCategory");
			}
			return View(model);
		}
	}
}
