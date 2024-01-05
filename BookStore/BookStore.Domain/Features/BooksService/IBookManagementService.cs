using BookStore.Domain.Dto_s;
using BookStore.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Features.BooksService
{
    public interface IBookManagementService
    {
        Task<IList<BookWithDetails>>
            GetBookAsync(int pageIndex, int pageSize, string sortBy);
		Task InsertBookAsync(CreateUpdateBookDto book);
	}
}
