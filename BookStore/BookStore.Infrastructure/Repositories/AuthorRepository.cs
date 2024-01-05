using BookStore.Domain.Entities.Authors;
using BookStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
	public class AuthorRepository : Repository<Author, Guid>, IAuthorRepository
	{
		public AuthorRepository(IApplicationDbContext context) : base((DbContext)context)
		{
		}
	}
}
