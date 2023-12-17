using Autofac;
using Practice1.Application.Features.HospitalManagement;
using Practice1.Domain.Features.HospitalManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoctorManagement>().As<IDoctorManagement>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PatientManagement>().As<IPatientManagement>()
                .InstancePerLifetimeScope();
        }
    }
}
