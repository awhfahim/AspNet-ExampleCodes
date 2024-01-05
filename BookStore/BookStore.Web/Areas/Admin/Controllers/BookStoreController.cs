using Autofac;
using BookStore.Infrastructure;
using BookStore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookStoreController : Controller
    {
        private ILifetimeScope _scope;
        private ILogger<BookStoreController> _logger;

        public BookStoreController(ILifetimeScope scope, ILogger<BookStoreController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InsertBook()
        {
            var model = _scope.Resolve<InsertBookModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertBook(InsertBookModel model)
        {
            model.Resolve(_scope);

            if (ModelState.IsValid)
            {
                await model.InsertBookAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetBooks()
        {
            var dataTable = new DataTablesAjaxRequestUtility(Request);
            var model = _scope.Resolve<BookListModel>();

            var data = await model.GetBookAsync(dataTable);
            return Json(data);
        }
    }
}
