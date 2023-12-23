using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Features.Category;

namespace ExpenseTracker.Application.Features.Category
{
	public class CategoryManagementService : ICategoryManagementService
	{
		private IApplicationUnitOfWork _unitOfWork;
		public CategoryManagementService(IApplicationUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

		public async Task AddCategoryAsync(Domain.Entities.Category category)
		{
			var user = new User();
			user.Expenses = new List<Expense>();
			
			await _unitOfWork.UserRepository.AddAsync(user);
			await _unitOfWork.SaveAsync();
		}
	}
}
