using FirstDemo.Infrastructure.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackOverflow.Domain.Entities;
using StackOverflow.Infrastructure.EntityConfigurations;
using StackOverflow.Infrastructure.Membership;

namespace StackOverflow.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Vote> Votes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Members { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssembly));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserEntityTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(UserEntityTypeConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(QuestionEntityTypeConfiguration).Assembly);

			builder.Entity<QuestionTag>(b => {
				b.ToTable("QestionTags"); 
       

                //define composite key
                b.HasKey(x=>new{x.QuestionId,x.TagId});

                //many-to-many configuration
                b.HasOne<Question>().WithMany().HasForeignKey(x=>x.QuestionId).IsRequired();
                b.HasOne<Tag>().WithMany().HasForeignKey(x=>x.TagId).IsRequired();
                b.HasIndex(x=>new{x.QuestionId,x.TagId});});

				base.OnModelCreating(builder);
        }
    }
}
