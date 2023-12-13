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

    }
}
