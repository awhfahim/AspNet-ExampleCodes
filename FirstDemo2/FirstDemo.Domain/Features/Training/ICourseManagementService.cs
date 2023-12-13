using FirstDemo2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo2.Domain.Features.Training
{
	public interface ICourseManagementService
	{
		void CreateCourse(Course course);
	}
}
