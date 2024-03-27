using Microsoft.EntityFrameworkCore;
using StackOverflow.Application;
using StackOverflow.Domain.Repositories;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {

        public ApplicationUnitOfWork(IApplicationDbContext dbContext) : base((DbContext)dbContext)
        {

        }

    }
}
