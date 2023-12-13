using Autofac;
using FirstDemo.Application;
using FirstDemo1.Application.Features.Training;
using FirstDemo1.Domain.Features.Training;
using static System.Formats.Asn1.AsnWriter;

namespace FirstDemo1.Web.Areas.Admin.Models
{
    public class CourseCreateModel
    {
        private ILifetimeScope _scope;
        private ICourseManagementService _courseManagementService;
        public string Title { get; set; }
        public string Description { get; set; }
        public uint Fees { get; set; }

        public CourseCreateModel() { }
        public CourseCreateModel(ICourseManagementService courseMangementService)
        {
			_courseManagementService = courseMangementService;
		}

		internal void Resolve(ILifetimeScope scope)
		{
			_scope = scope;
			_courseManagementService = _scope.Resolve<ICourseManagementService>();
		}

		internal void CreateCourse()
        {
			_courseManagementService.CreateCourse(Title, Description, Fees);
        }
    }
}
