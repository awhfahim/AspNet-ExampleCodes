using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {

	}
}
