using Autofac;
using ExpenseTracker.Application.Features.Category;
using ExpenseTracker.Domain.Features.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManagementService>().As<ICategoryManagementService>()
                .InstancePerLifetimeScope();
        }
    }
}
