using Exam1.Domain.Entities;
using Exam1.Domain.Features.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application.Features.CategoryServices
{
    public class CategoryManagementService : ICategoryManagementService
    {
        private IApplicationUnitOfWork _unitOfWork;
        public CategoryManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }
    }
}
