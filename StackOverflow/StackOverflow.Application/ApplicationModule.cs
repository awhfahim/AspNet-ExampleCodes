using Autofac;
using StackOverflow.Application.Features.AccountManagementServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManagementService>().As<IUserManagementService>()
				.InstancePerLifetimeScope();
        }
    }
}
