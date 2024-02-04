using Autofac;
using CustomizingIdentityFramework.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizingIdentityFramework.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
