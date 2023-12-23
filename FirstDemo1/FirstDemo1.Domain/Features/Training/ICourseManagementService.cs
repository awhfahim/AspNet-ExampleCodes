using FirstDemo1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo1.Domain.Features.Training
{
    public interface ICourseManagementService
    {
        void CreateCourse(string Title, string Description, uint fees);
        Task DeleteCourseAsync(Guid id);

        Task<(IList<Course> records, int total, int totalDisplay)>
            GetPagedCoursesAsync(int pageIndex, int pageSize, string searchText,
            string sortBy);
    }
}
