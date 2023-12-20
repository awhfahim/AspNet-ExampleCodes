using Autofac;
using Practice1.Web.Areas.Hospital.Models;

namespace Practice1.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddDoctorModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<AddPatientModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<DoctorListModel>().AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
