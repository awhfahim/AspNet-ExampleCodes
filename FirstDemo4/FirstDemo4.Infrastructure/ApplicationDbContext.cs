using ExpenseTracker.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> UserExpenses { get; set; }
		public DbSet<Category> Categories { get; set; }

    }
}