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
	public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
	{
		public void Configure(EntityTypeBuilder<Question> builder)
		{
			builder.HasKey(q => q.Id);
			builder.Property(q => q.Id).ValueGeneratedOnAdd();
			builder.Property(q => q.Title).IsRequired().HasMaxLength(250);
			builder.Property(q => q.Body).IsRequired().HasMaxLength(5000);
			builder.Property(q => q.CreatedAt).IsRequired();
			builder.Property(q => q.UpdatedAt).IsRequired();
			builder.Property(q => q.Votes).IsRequired();
			builder.Property(q => q.AnswersCount).IsRequired();
			builder.Property(q => q.UserId).IsRequired();


			builder.HasMany<Answer>()
				.WithOne()
				.HasForeignKey(a => a.QuestionId);
		}
	}
}
