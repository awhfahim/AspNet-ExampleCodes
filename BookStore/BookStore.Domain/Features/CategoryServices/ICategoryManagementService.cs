using BookStore.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Features.CategoryServices
{
	public interface ICategoryManagementService
	{
		Task<ICollection<(Guid a, string name)>> GetCategoriesAsync();
	}
}
