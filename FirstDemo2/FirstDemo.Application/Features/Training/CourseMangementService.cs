using FirstDemo2.Domain.Entities;
using FirstDemo2.Domain.Features.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo2.Application.Features.Training
{
	public class CourseMangementService : ICourseManagementService
	{
		private IApplicationUnitOfWork _unitOfWork;
		public CourseMangementService(IApplicationUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

		public void CreateCourse(Course course)
		{
			_unitOfWork.CourseRepository.Add(course);
			_unitOfWork.Save();
		}
	}
}
