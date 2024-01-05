using Autofac;
using BookStore.Web.Areas.Admin.Models;

namespace BookStore.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookListModel>().AsSelf();
            builder.RegisterType<InsertBookModel>().AsSelf();
        }
    }
}
