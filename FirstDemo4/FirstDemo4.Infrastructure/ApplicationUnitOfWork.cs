using ExpenseTracker.Application;
using ExpenseTracker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
		public IUserRepository UserRepository { get; private set; }
        public ApplicationUnitOfWork(IApplicationDbContext dbContext, IUserRepository userRepository) : base((DbContext)dbContext)
        {
            UserRepository = userRepository;
        }

	}
}
