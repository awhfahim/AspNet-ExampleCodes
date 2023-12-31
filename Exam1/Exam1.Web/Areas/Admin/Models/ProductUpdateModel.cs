using Autofac;
using AutoMapper;
using Exam1.Domain.Features.ProductsServices;
using System.ComponentModel.DataAnnotations;

namespace Exam1.Web.Areas.Admin.Models
{
    public class ProductUpdateModel
    {
        private IProductService _productService;
        private IMapper _mapper;

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Range(0, 1000000, ErrorMessage = "Price Should be between 0 & 1000000")]
        public uint Price { get; set; }

        [Required]
        public double Weight { get; set; }

        public ProductUpdateModel() { }
        public ProductUpdateModel(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        internal void Resolve(ILifetimeScope scope)
            => (_productService, _mapper) = (scope.Resolve<IProductService>(), scope.Resolve<IMapper>());

        internal async Task LoadAsync(Guid id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product is not null)
            {
                _mapper.Map(product, this);
            }
        }

        internal async Task UpdateCourseAsync()
        {
            if (!string.IsNullOrWhiteSpace(Name) && Price >= 0) 
            {
                await _productService.UpdateProductAsync(Id, Name, Price, Weight);
            }
        }
    }
}
