using Exam1.Domain.Entities;
using Exam1.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> GetTableDataAsync(string searchTitle, string orderBy, int pageIndex, int pageSize)
        {
            return await GetDynamicAsync(x => x.Name!.Contains(searchTitle),
                 orderBy, null, pageIndex, pageSize, true);
        }

        public async Task<bool> IsDuplicateAsync(string name, Guid? Id = null)
        {
            if(Id.HasValue)
               return await GetCountAsync(x => x.Id != Id.Value && x.Name == name) > 0;
            else
                return await GetCountAsync(x => x.Name == name) > 0;
        }

    }
}
