using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}