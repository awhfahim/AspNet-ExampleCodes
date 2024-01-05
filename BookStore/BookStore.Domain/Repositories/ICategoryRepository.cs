using BookStore.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repositories
{
	public interface ICategoryRepository : IRepositoryBase<Category, Guid>
	{
		Task<List<(Guid a, string name)>> GetCustomCategory();
	}
}
