using Autofac;
using Exam1.Application.Features.CategoryServices;
using Exam1.Application.Features.ProductsServices;
using Exam1.Domain.Features.CategoryServices;
using Exam1.Domain.Features.ProductsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope ();
            
            builder.RegisterType<CategoryManagementService>().As<ICategoryManagementService>()
                .InstancePerLifetimeScope ();
        }
    }
}
