using FirstDemo.Application;
using FirstDemo1.Domain.Entities;
using FirstDemo1.Domain.Features.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo1.Application.Features.Training
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public CourseManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCourse(string Title, string Description, uint fees)
        {
            var course = new Course() { Title = Title, Description = Description, Fees = fees };
            _unitOfWork.CourseRepository.Add(course);
            _unitOfWork.Save();
        }

        public async Task<(IList<Course> records, int total, int totalDisplay)>
            GetPagedCoursesAsync(int pageIndex, int pageSize,
                string searchText, string sortBy)
        {
            return await _unitOfWork.CourseRepository.GetTableDataAsync(searchText, sortBy,
                pageIndex, pageSize);
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            await _unitOfWork.CourseRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
