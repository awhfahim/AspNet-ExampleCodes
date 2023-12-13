using Autofac;
using FirstDemo2.Web.Areas.Admin.Models;

namespace FirstDemo2.Web
{
	public class WebModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CourseCreateModel>().AsSelf();
		}
	}
}
