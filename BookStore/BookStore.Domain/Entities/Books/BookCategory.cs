using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities.Books
{
    public class BookCategory : Entity<Guid>
    {
        public Guid BookId { get; private set; }
        public Guid CategoryId { get; private set; }

        private BookCategory() { }

        public BookCategory(Guid bookId, Guid categoryId)
        {
            BookId = bookId;
            CategoryId = categoryId;
        }
    }
}
