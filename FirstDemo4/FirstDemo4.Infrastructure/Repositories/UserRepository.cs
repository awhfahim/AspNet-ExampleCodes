using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

    }
}
