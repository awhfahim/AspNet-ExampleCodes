using Exam1.Domain.Entities;
using Exam1.Domain.Features.CategoryServices;
using Exam1.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}
