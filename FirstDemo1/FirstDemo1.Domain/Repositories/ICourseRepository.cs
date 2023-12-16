using FirstDemo1.Domain.Repositories;
using FirstDemo1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo1.Domain.Repositories
{
    public interface ICourseRepository : IRepositoryBase<Course, Guid>
    {
        Task<(IList<Course> records, int total, int totalDisplay)>
            GetTableDataAsync(string searchText, string orderBy,
                int pageIndex, int pageSize);
    }
}
