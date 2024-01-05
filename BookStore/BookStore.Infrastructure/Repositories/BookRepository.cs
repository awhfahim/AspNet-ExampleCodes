using BookStore.Domain.Entities.Authors;
using BookStore.Domain.Entities.Books;
using BookStore.Domain.Entities.Categories;
using BookStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        private readonly IApplicationDbContext _context;
        public BookRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            _context = context;
        }

        public async Task<List<BookWithDetails>> GetListAsync(
            string sorting,
            int skipCount,
            int maxResultCount
        )
        {
            //var query = await ApplyFilterAsync();

            var result = _context.Books.Include(x => x.Categories).Join(_context.Authors, book => book.AuthorId, author
                => author.Id, (book, author) => new { book, author })
                .Select(x => new BookWithDetails
                {
                    Id = x.book.Id,
                    Name = x.book.Name,
                    Price = x.book.Price,
                    PublishDate = x.book.PublishDate,
                    AuthorName = x.author.Name,
                    CategoryNames = (from bookCategories in x.book.Categories
                                     join category in _context.Categories on bookCategories.CategoryId equals category.Id
                                     select category.Name).ToArray()
                });

            var res = _context.Books.ToList();

            return await result
                .OrderBy(!string.IsNullOrWhiteSpace(sorting) ? sorting : nameof(Book.Name))
                .PageBy(skipCount, maxResultCount)
                .ToListAsync();
        }

        public async Task<BookWithDetails> GetAsync(Guid id)
        {
            IQueryable<BookWithDetails> query = await ApplyFilterAsync();

            if(query is not null)
                await query
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return null;
        }

        private async Task<IQueryable<BookWithDetails>> ApplyFilterAsync()
        {

            return await (Task<IQueryable<BookWithDetails>>)(_context.Books)
                .Include(x => x.Categories)
                .Join(_context.Authors, book => book.AuthorId, author => author.Id,
                    (book, author) => new { book, author })
                .Select(x => new BookWithDetails
                {
                    Id = x.book.Id,
                    Name = x.book.Name,
                    Price = x.book.Price,
                    PublishDate = x.book.PublishDate,
                    AuthorName = x.author.Name,
                    CategoryNames = (from bookCategories in x.book.Categories
                                     join category in _context.Categories on bookCategories.CategoryId equals category.Id
                                     select category.Name).ToArray()
                });

        }
    }
}
