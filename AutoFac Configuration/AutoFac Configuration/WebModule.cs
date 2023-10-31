using Autofac;
using AutoFac_Configuration.Models;

namespace AutoFac_Configuration
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailUtility>().As<IEmailUtility>()
                .InstancePerLifetimeScope();
        }
    }
}
