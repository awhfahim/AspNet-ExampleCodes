using FirstDemo2.Application;
using FirstDemo2.Domain.Repositories;
using FirstDemo2.Infrastructure.Repositories;
using FirstDemo2.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo2.Infrastructure
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
