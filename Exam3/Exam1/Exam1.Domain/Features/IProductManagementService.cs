using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Features
{
    public interface IProductManagementService
    {
        Task AddProductAsync(string name, uint price, uint weight);
        Task DeleteProductAsync(Guid id);
        Task<(string name, uint price, uint weight)> GetProductAsync(Guid id);

        Task<(ICollection<Product> record, int total, int totalDisplay)> 
            GetProductsAsync(int pageIndex, int pageSize, string name, uint priceFrom, uint priceTo, string sortBy);
        Task UpdateProductAsync(Guid Id,string name, uint price, uint weight);
    }
}
