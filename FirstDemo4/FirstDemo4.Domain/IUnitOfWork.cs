using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
        void Dispose();
        Task DisposeAsync();
    }
}
