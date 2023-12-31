using Autofac;
using Exam1.Domain.Exceptions;
using Exam1.Infrastructure;
using Exam1.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam1.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ILogger<ProductController> _logger;
        private ILifetimeScope _scope;

        public ProductController(ILogger<ProductController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            var model = _scope.Resolve<AddProductModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductModel model)
        {
            model.Resolve(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    await model.AddProductAsync();

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Product created successfuly",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch(DuplicateValueException ex)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch(Exception ex)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }
            }
            return View(model);
        }

        public async Task<JsonResult> GetProducts(ProductListModel model)
        {
            model.Resolve(_scope);
            var dataTablesModel = new DataTablesAjaxRequestUtility(Request);

            var data = await model.GetPagedProductsAsync(dataTablesModel);
            return Json(data);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = _scope.Resolve<ProductUpdateModel>();
            await model.LoadAsync(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateModel model)
        {
            model.Resolve(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    await model.UpdateCourseAsync();
                    return RedirectToAction("Index");
                }
                catch(DuplicateValueException ex)
                {
                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }
                catch (Exception ex)
                {
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Try Again Later",
                        Type = ResponseTypes.Danger
                    });
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var model = _scope.Resolve<ProductListModel>();
            if (ModelState.IsValid)
            {
                try
                {
                    await model.DeleteProductAsync(Id);
                   
                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Product Deleted Successfully",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Server Error");

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "There was a problem in deleting course",
                        Type = ResponseTypes.Danger
                    });
                }
            }

            return RedirectToAction("Index");
        }
    }
}
