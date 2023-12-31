using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Features.ProductsServices
{
    public interface IProductService
    {
        Task AddProductAsync(string name, uint price, double weight, Guid SelectedCategory);
        Task DeleteProductAsync(Guid id);

        Task<(IList<ProductWithCategory> records, int total, int totalDisplay)> 
            GetPagedProductsAsync(int pageIndex, int pageSize, string searchText, string v);
        Task<Product> GetProductAsync(Guid id);
        Task UpdateProductAsync(Guid Id, string name, uint price, double weight);

        Task<IList<Category>> GetCategories();
    }
}
