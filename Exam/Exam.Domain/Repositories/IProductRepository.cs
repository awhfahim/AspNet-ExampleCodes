using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, Guid>
    {
    }
}
