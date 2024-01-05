using BookStore.Application;
using BookStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }

		public IAuthorRepository AuthorRepository { get; set; }

		public ICategoryRepository CategoryRepository {  get; set; }

		public ApplicationUnitOfWork(IApplicationDbContext dbContext, IBookRepository bookRepository,
            IAuthorRepository authorRepository, ICategoryRepository categoryRepository) : base((DbContext)dbContext)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;
            CategoryRepository = categoryRepository;
        }

    }
}
