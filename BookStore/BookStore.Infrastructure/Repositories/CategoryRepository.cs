using BookStore.Domain.Entities.Categories;
using BookStore.Domain.Repositories;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
	public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
	{
		private readonly IApplicationDbContext _context;
		public CategoryRepository(IApplicationDbContext context) : base((DbContext)context)
		{
			_context = context;
		}

		public async Task<List<(Guid a, string name)>> GetCustomCategory()
		{
			List<(Guid a,string name)> values = new List<(Guid a, string name)> ();
			var r = await _context.Categories.Select(x => new {x.Id, x.Name}).ToListAsync();
			
			foreach (var category in r)
			{
				values.Add((category.Id, category.Name));
			}
			return values;
		}
	}
}
