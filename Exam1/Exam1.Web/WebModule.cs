﻿using Autofac;
using Exam1.Web.Areas.Admin.Models;

namespace Exam1.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddProductModel>().AsSelf();
            builder.RegisterType<ProductListModel>().AsSelf();
            builder.RegisterType<ProductUpdateModel>().AsSelf();
        }
    }
}
