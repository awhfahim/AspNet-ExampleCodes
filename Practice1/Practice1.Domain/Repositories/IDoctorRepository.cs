using Practice1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Domain.Repositories
{
    public interface IDoctorRepository : IRepositoryBase<Doctor, Guid>
    {
        Task<bool> IsDuplicateAsync(string name, Guid? Id = null);

        Task<(IList<Doctor> records, int total, int totalDisplay)>
            GetTableDataAsync(string searchText, string orderBy,
                int pageIndex, int pageSize);
    }
}
