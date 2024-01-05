using BookStore.Domain.Entities.Categories;
using BookStore.Domain.Features.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.CategoryServices
{
	public class CategoryManagementService : ICategoryManagementService
	{
		private readonly IApplicationUnitOfWork _unitOfWork;
		public CategoryManagementService(IApplicationUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ICollection<(Guid a, string name)>> GetCategoriesAsync()
		{
			return await _unitOfWork.CategoryRepository.GetCustomCategory();
		}

	}

}
