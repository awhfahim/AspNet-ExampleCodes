using Autofac;
using Exam1.Domain.Features;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        private IProductManagementService _productManagementService;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public uint Weight { get; set; }

        public ProductUpdateModel() { }
        public ProductUpdateModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _productManagementService = scope.Resolve<IProductManagementService>();
        }

        internal async Task GetProuctAsync(Guid id)
        {
            var res = await _productManagementService.GetProductAsync(id);
            Name = res.name; Price = res.price; Weight = res.weight;
        }

        internal async Task UpdateProductAsync()
        {
            await _productManagementService.UpdateProductAsync(Id,Name, Price, Weight);
        }
    }
}
