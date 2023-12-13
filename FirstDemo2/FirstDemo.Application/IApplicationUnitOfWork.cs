using FirstDemo2.Domain;
using FirstDemo2.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo2.Application
{
	public interface IApplicationUnitOfWork : IUnitOfWork
	{
		ICourseRepository CourseRepository { get; }	
	}
}
