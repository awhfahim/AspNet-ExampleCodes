using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {

    }
}