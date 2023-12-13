﻿using Autofac;
using FirstDemo2.Domain.Entities;
using FirstDemo2.Domain.Features.Training;

namespace FirstDemo2.Web.Areas.Admin.Models
{
    public class CourseCreateModel
    {
		private ILifetimeScope _scope;
		private ICourseManagementService _courseManagementService;
        public string Title { get; set; }
        public string Description { get; set; }
        public uint Fees { get; set; }

		public CourseCreateModel() { }

		public CourseCreateModel(ICourseManagementService courseManagementService)
		{
			_courseManagementService = courseManagementService;
		}

		internal void Resolve(ILifetimeScope scope)
		{
			_scope = scope;
			_courseManagementService = _scope.Resolve<ICourseManagementService>();
		}

		internal void CreateCourse()
		{
			var course = new Course() {Title = Title, Description = Description, Fees = Fees};
			_courseManagementService.CreateCourse(course);
		}
	}
}
