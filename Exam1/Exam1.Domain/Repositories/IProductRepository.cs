using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
        Task<bool> IsDuplicateAsync(string name, Guid? Id = null);

        Task<(IList<Product> records, int total, int totalDisplay)>
            GetTableDataAsync(string searchTitle, string orderBy, int pageIndex, int pageSize);
    }
}
