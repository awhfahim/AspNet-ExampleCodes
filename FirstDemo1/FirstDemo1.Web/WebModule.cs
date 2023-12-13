using Autofac;
using FirstDemo1.Web.Areas.Admin.Models;

namespace FirstDemo1.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseCreateModel>().AsSelf();
        }
    }
}
