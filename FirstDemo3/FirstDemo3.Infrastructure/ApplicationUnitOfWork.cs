using FirstDemo3.Application;
using FirstDemo3.Domain.Repositories;
using FirstDemo3.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Infrastructure
{
	public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
	{
		public IRoundTripRepository RoundTripRepositories { get; private set; }
		public ApplicationUnitOfWork(ApplicationDbContext dbContext, IRoundTripRepository roundTripRepositories) : base(dbContext)
		{
			RoundTripRepositories = roundTripRepositories;
		}

		
	}
}
