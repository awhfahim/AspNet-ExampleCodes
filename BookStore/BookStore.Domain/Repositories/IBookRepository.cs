using BookStore.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repositories
{
    public interface IBookRepository : IRepositoryBase<Book, Guid>
    {
        Task<List<BookWithDetails>> GetListAsync(
            string sorting,
            int pageIndex,
            int pageSize);

        Task<BookWithDetails> GetAsync(Guid id);
    }
}
