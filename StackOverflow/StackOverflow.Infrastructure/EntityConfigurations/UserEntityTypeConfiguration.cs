using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.EntityConfigurations
{
	public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.DisplayName).HasMaxLength(50).IsRequired();
			builder.Property(e => e.FullName).HasMaxLength(100);
			builder.Property(e => e.Location).HasMaxLength(100);
			builder.Property(e => e.AboutMe).HasMaxLength(1000);
			builder.Property(e => e.WebsiteLink).HasMaxLength(100);
			builder.Property(e => e.TwitterUsername).HasMaxLength(15);
			builder.Property(e => e.GitHubUsername).HasMaxLength(39);
			builder.Property(e => e.ProfileImageUrl).HasMaxLength(100);
			

			builder.HasMany<Answer>()
				.WithOne()
				.HasForeignKey(e => e.UserId)
				.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
				.IsRequired();

			builder.HasMany<Question>()
				.WithOne()
				.HasForeignKey(e => e.UserId)
				.OnDelete(deleteBehavior: DeleteBehavior.Cascade)
				.IsRequired();

			builder.HasMany<Vote>()
				.WithOne()
				.HasForeignKey(e => e.UserId)
				.OnDelete(deleteBehavior: DeleteBehavior.Cascade)
				.IsRequired();
		}
	}
}
