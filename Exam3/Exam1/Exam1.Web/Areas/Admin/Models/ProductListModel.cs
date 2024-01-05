using Autofac;
using Exam1.Domain.Features;
using Exam1.Infrastructure.Utilities;
using System.Web;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private IProductManagementService _productManagementService;

        public SearchProduct SearchProduct { get; set; }

        public ProductListModel()
        { }
        public ProductListModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _productManagementService = scope.Resolve<IProductManagementService>();
        }

        internal async Task<object> GetProductsAsync(DataTablesAjaxRequestUtility dataTable)
        {
            var data = await _productManagementService.GetProductsAsync(dataTable.PageIndex,
                dataTable.PageSize,
                SearchProduct.Name,
                SearchProduct.PriceFrom,
                SearchProduct.PriceTo,
                dataTable.GetSortText(new string[] {"Name", "Price"}));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.record
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.Name),
                                record.Price.ToString(),
                                record.Weight.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };

        }

        internal async Task DeleteProductAsync(Guid id)
        {
            await _productManagementService.DeleteProductAsync(id);
        }
    }
}
