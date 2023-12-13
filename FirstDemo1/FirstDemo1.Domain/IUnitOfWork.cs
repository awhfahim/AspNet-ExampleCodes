using System;
using System.Collections.Generic;
using System.Text;

namespace FirstDemo1.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
