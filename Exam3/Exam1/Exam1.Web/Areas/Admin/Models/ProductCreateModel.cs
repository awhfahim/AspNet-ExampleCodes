
using Autofac;
using Exam1.Domain.Features;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductCreateModel
    {
        private IProductManagementService _productManagementService;
        public string Name { get; set; }
        public uint Price { get; set; }
        public uint Weight { get; set; }

        public ProductCreateModel() { }

        public ProductCreateModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }
        
        internal void Resolve(ILifetimeScope scope)
        {
            _productManagementService = scope.Resolve<IProductManagementService>();
        }
        internal async Task AddProductAsync()
        {
            await _productManagementService.AddProductAsync(Name, Price, Weight);
        }
    }
}
