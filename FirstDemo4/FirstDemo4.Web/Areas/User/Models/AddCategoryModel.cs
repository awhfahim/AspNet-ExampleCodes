using Autofac;
using ExpenseTracker.Domain.Features.Category;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Web.Areas.User.Models
{
	public class AddCategoryModel
	{

		public Guid Id { get; set; }
		[Required]
		public string? CategoryName { get; set; }

		public AddCategoryModel() { }
		private ICategoryManagementService _categoryManagementService;
		public AddCategoryModel(ICategoryManagementService categoryManagementService) 
			=> _categoryManagementService = categoryManagementService;

		internal void Resolve(ILifetimeScope scope) 
			=> _categoryManagementService = scope.Resolve<ICategoryManagementService>();
		internal async Task AddCategoryTask(AddCategoryModel model)
		{
			await _categoryManagementService.
		}
	}
}
