using ExpenseTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<User> UserExpenses { get; }
        DbSet<Category> Categories { get; }
    }
}
