using Autofac;
using Exam1.Domain.Entities;
using Exam1.Domain.Features.CategoryServices;
using Exam1.Domain.Features.ProductsServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exam1.Web.Areas.Admin.Models
{
    public class AddProductModel
    {
        private IProductService _productService;
        private ICategoryManagementService _categoryManagementService;
        public string Name { get; set; }
        public uint Price { get; set; }
        public double Weight { get; set; }
        public Guid SelectedCategory { get; set; }

        public AddProductModel() { }
        public AddProductModel(IProductService productService, ICategoryManagementService categoryManagementService)
        {
            _productService = productService;
            _categoryManagementService = categoryManagementService;
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _productService = scope.Resolve<IProductService>();
            _categoryManagementService = scope.Resolve<ICategoryManagementService>();
        }

        internal async Task AddProductAsync()
        {
            await  _productService.AddProductAsync(Name,Price, Weight, SelectedCategory);
        }

        internal async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryManagementService.GetAllCategory();
        }     
    }
}
