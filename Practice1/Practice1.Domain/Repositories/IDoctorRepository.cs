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
    }
}
