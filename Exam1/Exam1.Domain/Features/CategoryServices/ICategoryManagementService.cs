using Exam1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Domain.Features.CategoryServices
{
    public interface ICategoryManagementService
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetById(Guid Id);
    }
}
