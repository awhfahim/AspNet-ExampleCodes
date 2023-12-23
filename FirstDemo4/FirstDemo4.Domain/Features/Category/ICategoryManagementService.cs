using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Features.Category
{
	public interface ICategoryManagementService
	{
		Task AddCategoryAsync(Entities.Category category);
	}
}
