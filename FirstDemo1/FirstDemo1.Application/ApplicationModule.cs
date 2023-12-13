using Autofac;
using FirstDemo1.Application.Features.Training;
using FirstDemo1.Domain.Features.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo1.Application
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CourseManagementService>().As<ICourseManagementService>()
				.InstancePerLifetimeScope();
		}
	}
}
