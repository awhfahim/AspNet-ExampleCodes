using Autofac;
using CustomizingIdentityFramework.Web.Models;

namespace CustomizingIdentityFramework.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegistrationModel>().AsSelf();
            builder.RegisterType<LogInModel>().AsSelf();
        }
    }
}
