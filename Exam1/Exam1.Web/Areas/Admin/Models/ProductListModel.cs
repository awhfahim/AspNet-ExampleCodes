using Autofac;
using Exam1.Domain.Entities;
using Exam1.Domain.Features.CategoryServices;
using Exam1.Domain.Features.ProductsServices;
using Exam1.Infrastructure;
using System.Web;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private IProductService productService;
        private ICategoryManagementService _categoryService;
        public ProductListModel() { }
        public ProductListModel(IProductService productService, ICategoryManagementService categoryManagementService)
        {  
            this.productService = productService;
            _categoryService = categoryManagementService;
        }


        internal void Resolve(ILifetimeScope scope)
        {
            productService = scope.Resolve<IProductService>();
            _categoryService = scope.Resolve<ICategoryManagementService>();
        }

        internal async Task<IEnumerable<Category>> FetchCategories()
         => await productService.GetCategories();

        internal async Task<object> GetPagedProductsAsync(DataTablesAjaxRequestUtility dataTablesUtility)
        {
            var data = await productService.GetPagedProductsAsync(dataTablesUtility.PageIndex,
                dataTablesUtility.PageSize,
                dataTablesUtility.SearchText,
                dataTablesUtility.GetSortText(new string[] {"Price","Name"}));


            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.Name),
                                record.Price.ToString(),
                                record.Weight.ToString(),
                                record.CategoryName,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal async Task DeleteProductAsync(Guid id)
        {
            await productService.DeleteProductAsync(id);
        }
    }
}
