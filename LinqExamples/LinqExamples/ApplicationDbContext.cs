using LinqExamples.IMDBd;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=.\\SQLEXPRESS;Database=CodingNinjas;User Id=fahim;Password=123456;Trust Server Certificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Earning>().HasNoKey();
            modelBuilder.Entity<genre>().HasNoKey();
            modelBuilder.Entity<IMDB>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Earning> earning { get; set; }
        public DbSet<genre> genre { get; set; }
        public DbSet<IMDB> IMDB { get; set; }
    }
}
