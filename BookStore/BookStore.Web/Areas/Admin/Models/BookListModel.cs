using Autofac;
using BookStore.Domain.Features.BooksService;
using BookStore.Infrastructure;
using System.Text;
using System.Web;

namespace BookStore.Web.Areas.Admin.Models
{
    public class BookListModel
    {
        private IBookManagementService _bookManagementService;
        public BookListModel() { }
        public BookListModel(IBookManagementService bookManagementService)
        {
            _bookManagementService = bookManagementService;
        }

        internal async Task<object> GetBookAsync(DataTablesAjaxRequestUtility dataTable)
        {
            var data = await _bookManagementService.GetBookAsync(dataTable.PageIndex,
                dataTable.PageSize,
                dataTable.GetSortText(new string[] {"Name", "Price"}));

            var result = from categoryName in data
                         select categoryName.CategoryNames;

            string a = "";
            foreach (var categoryName in result)
            {
                foreach (var c in categoryName)
                    a += c;
            }

            return new
            {
                data = (from record in data
                        select new string[]
                        {
                                HttpUtility.HtmlEncode(record.Name),
                                record.PublishDate.ToString(),
                                HttpUtility.HtmlEncode(record.AuthorName),
                                record.Price.ToString(),
                                a,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _bookManagementService = scope.Resolve<IBookManagementService>();
        }
    }
}
