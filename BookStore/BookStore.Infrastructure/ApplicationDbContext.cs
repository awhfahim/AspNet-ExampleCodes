using BookStore.Domain.Entities.Authors;
using BookStore.Domain.Entities.Books;
using BookStore.Domain.Entities.Categories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>(
                b =>
                {      
                    b.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                    b.Property(x => x.ShortBio)
                    .HasMaxLength(250)
                    .IsRequired();
                });

            builder.Entity<Book>(b =>
                {
                    b.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                    b.HasOne<Author>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();
                    b.HasMany(x => x.Categories).WithOne().HasForeignKey(x => x.BookId).IsRequired();
                });

            builder.Entity<BookCategory>(b =>
            {
                b.HasKey(x => new {x.BookId, x.CategoryId});

                b.HasOne<Book>().WithMany(x => x.Categories).HasForeignKey(x => x.BookId).IsRequired();
                b.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId).IsRequired();

                b.HasIndex(x => new {x.BookId, x.CategoryId});
            });

            builder.Entity<Author>().HasData(new Author[]
            {
                new Author(
                        "Dan Brown",
                        new DateTime(1964, 06, 22),
                        "Daniel Gerhard Brown (born June 22, 1964) is an American author best known for his thriller novels"
                    ){Id = Guid.NewGuid() } ,
                new Author(
                        "George Orwell",
                        new DateTime(1903, 06, 25),
                  "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                    ){Id = Guid.NewGuid() }
            });

            builder.Entity<Category>().HasData(new Category[]
            {
                new Category("History"){ Id = Guid.NewGuid() },
                new Category("Adventure"){ Id = Guid.NewGuid() },
                new Category("Action"){ Id = Guid.NewGuid() },
                new Category("Crime"){ Id = Guid.NewGuid() },
                new Category("Dystopia"){ Id = Guid.NewGuid() },
            });
        }

    }
}
