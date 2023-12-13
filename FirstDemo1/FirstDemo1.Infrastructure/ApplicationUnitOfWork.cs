using FirstDemo.Application;
using FirstDemo1.Domain.Repositories;
using FirstDemo1.Infrastructure;
using FirstDemo1.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Infrastructure
{
	public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
	{
		public ICourseRepository CourseRepository { get; private set; }

		public ApplicationUnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
		{
			CourseRepository = new CourseRepository(dbContext);
		}

    }
}
