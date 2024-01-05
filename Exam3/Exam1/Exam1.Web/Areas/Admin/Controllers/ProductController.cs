using Autofac;
using Exam1.Infrastructure.Utilities;
using Exam1.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;

namespace Exam1.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ILifetimeScope _scope;

        public ProductController(ILogger<ProductController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<ProductCreateModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            model.Resolve(_scope);
            if (ModelState.IsValid)
            {
                await model.AddProductAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> GetProducts(ProductListModel model)
        {
            model.Resolve(_scope);
            var dataTable = new DataTablesAjaxRequestUtility(Request);

            var data =await model.GetProductsAsync(dataTable);
            return Json(data);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            if(ModelState.IsValid)
            {
                var model = _scope.Resolve<ProductListModel>();
                await model.DeleteProductAsync(Id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var model = _scope.Resolve<ProductUpdateModel>();
            await model.GetProuctAsync(Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateModel model)
        {
            model.Resolve(_scope);
            if (ModelState.IsValid)
            {
                await model.UpdateProductAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
