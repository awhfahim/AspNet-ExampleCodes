using ExpenseTracker.Domain;
using ExpenseTracker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
