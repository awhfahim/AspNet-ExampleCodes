using StackOverflow.Domain;
using StackOverflow.Domain.Repositories;

namespace StackOverflow.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository { get; }
    }
}
