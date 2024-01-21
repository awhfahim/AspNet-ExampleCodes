﻿using Autofac;
using FirstDemo.Web.Areas.Admin.Models;
using FirstDemo.Web.Models;
using System.Xml.Serialization;

namespace FirstDemo.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnicodeSmsSender>().As<ISmsSender>();
            builder.RegisterType<CourseCreateModel>().AsSelf();
            builder.RegisterType<CourseUpdateModel>().AsSelf();
            builder.RegisterType<CourseListModel>().AsSelf();
            builder.RegisterType<RegistrationModel>().AsSelf();
        }
    }
}
