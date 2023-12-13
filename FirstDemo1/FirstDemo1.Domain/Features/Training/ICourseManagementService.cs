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
    }
}
