﻿using FirstDemo3.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstDemo3.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
		private readonly string _connectionString;
		private readonly string _migrationAssembly;

		public ApplicationDbContext(string connectionString, string migrationAssembly)
		{
			_connectionString = connectionString;
			_migrationAssembly = migrationAssembly;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_connectionString,
					x => x.MigrationsAssembly(_migrationAssembly));
			}

			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<RoundTrip> RoundTrips { get; set; }
	}
}