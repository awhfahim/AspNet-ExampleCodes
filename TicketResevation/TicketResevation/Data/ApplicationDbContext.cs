using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketResevation.Models;

namespace TicketResevation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VV9FUDF\\SQLEXPRESS;Database=FinalProject;User Id=final;Password=123456;Trust Server Certificate=True;");
        }
        public DbSet<Register> Registers { get; set; }
    }
}