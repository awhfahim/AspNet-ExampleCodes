using Autofac;
using StackOverflow.Application;
using StackOverflow.Application.Utilities;
using StackOverflow.Domain.Repositories;
using StackOverflow.Infrastructure.DbContexts;
using StackOverflow.Infrastructure.Email;
using StackOverflow.Infrastructure.Repositories;
using StackOverflow.Infrastructure.UnitOfWorks;

namespace StackOverflow.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;
        public InfrastructureModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HtmlEmailService>().As<IEmailService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<UserRepository>().As<IUserRepository>()
                .InstancePerLifetimeScope();


            //         builder.RegisterType<TokenService>().As<ITokenService>()
            //            .InstancePerLifetimeScope();
        }
    }
}
