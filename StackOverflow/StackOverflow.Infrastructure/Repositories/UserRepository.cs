using Microsoft.EntityFrameworkCore;
using StackOverflow.Domain.Entities;
using StackOverflow.Domain.Repositories;
using StackOverflow.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.Repositories
{
	public class UserRepository : Repository<User, Guid>, IUserRepository
	{
		public UserRepository(IApplicationDbContext context) : base((DbContext)context)
		{
		}
	}
}
