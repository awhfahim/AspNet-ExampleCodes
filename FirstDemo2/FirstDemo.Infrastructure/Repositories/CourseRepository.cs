using FirstDemo2.Domain.Entities;
using FirstDemo2.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo2.Infrastructure.Repositories
{
	public class CourseRepository : Repository<Course, Guid>, ICourseRepository
	{
		public CourseRepository(DbContext context) : base(context)
		{
		}
	}
}
