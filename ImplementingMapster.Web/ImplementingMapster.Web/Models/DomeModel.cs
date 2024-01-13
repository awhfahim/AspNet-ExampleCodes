using ImplementingMapster.Domain;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ImplementingMapster.Models
{
    public class DomeModel
    {
        private ProductManagementService _productService;

        public DomeModel()
        {
        }

        //public DomeModel(ProductManagementService productService)
        //{
        //    _productService = productService;
        //}

        public async void DtoMap()
        {

        }
    }
}
