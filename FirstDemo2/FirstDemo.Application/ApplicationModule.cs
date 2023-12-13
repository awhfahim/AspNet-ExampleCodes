using Autofac;
using FirstDemo2.Application.Features.Training;
using FirstDemo2.Domain.Features.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo2.Application
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CourseMangementService>().As<ICourseManagementService>()
				.InstancePerLifetimeScope();
		}
	}
}
