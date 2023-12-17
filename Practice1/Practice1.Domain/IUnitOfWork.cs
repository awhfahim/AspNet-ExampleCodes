using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Domain
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
