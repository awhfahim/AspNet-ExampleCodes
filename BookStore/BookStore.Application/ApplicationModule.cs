using Autofac;
using BookStore.Application.Features.AuthorService;
using BookStore.Application.Features.BooksService;
using BookStore.Application.Features.CategoryServices;
using BookStore.Domain.Features.AuthorService;
using BookStore.Domain.Features.BooksService;
using BookStore.Domain.Features.CategoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookManagementService>().As<IBookManagementService>()
                .InstancePerLifetimeScope ();
            
            builder.RegisterType<AuthorManagementService>().As<IAuthorManagementService>()
                .InstancePerLifetimeScope ();
            
            builder.RegisterType<CategoryManagementService>().As<ICategoryManagementService>()
                .InstancePerLifetimeScope ();
        }
    }
}
