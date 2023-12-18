using Autofac;
using Practice1.Web.Areas.Hospital.Models;

namespace Practice1.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            throw new NotImplementedException();
            builder.RegisterType<AddDoctorModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<AddPatientModel>().AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
