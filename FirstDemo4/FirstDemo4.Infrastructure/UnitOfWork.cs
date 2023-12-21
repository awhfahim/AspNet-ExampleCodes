using ExpenseTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;
        public void Save() => _dbContext.SaveChanges();
        public void Dispose() => _dbContext.Dispose();
        public async Task DisposeAsync() => await _dbContext.DisposeAsync();
        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
