using BookStore.Domain.Dto_s;
using BookStore.Domain.Entities.Books;
using BookStore.Domain.Features.BooksService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.BooksService
{
    public class BookManagementService : IBookManagementService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public BookManagementService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<IList<BookWithDetails>> GetBookAsync(int pageIndex, int pageSize, string sortBy)
        {
            return await _applicationUnitOfWork.BookRepository.GetListAsync(sortBy, pageIndex, pageSize);
        }

		public async Task InsertBookAsync(CreateUpdateBookDto book)
		{
            var bk = new Book(book.AuthorId, book.Name, book.PublishDate, book.Price);
            foreach(var b in book.CategoryName)
            {
                bk.AddCategory(b);
            }
            await _applicationUnitOfWork.BookRepository.AddAsync(bk);
            await _applicationUnitOfWork.SaveAsync();
		}
	}
}
