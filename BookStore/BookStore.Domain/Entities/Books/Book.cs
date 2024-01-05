using Abp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookStore.Domain.Entities.Books
{
    public class Book : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Name { get; private set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }
        public ICollection<BookCategory> Categories { get; set; }
        private Book() { }
        public Book(Guid authorId, string name, DateTime publishDate, float price)
        {
            AuthorId = authorId;
            SetName(name);
            PublishDate = publishDate;
            Price = price;
            Categories = new Collection<BookCategory>();
        }

        private void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public void AddCategory(Guid categoryId)
        {
            Check.NotNull(categoryId, nameof(categoryId));
            if(IsInCategory(categoryId))
            {
                return;
            }
            Categories.Add(new BookCategory(bookId: Id, categoryId));
        }

        public void RemoveCategory(Guid categoryId)
        {
            Check.NotNull(categoryId, nameof(categoryId));

            if (!IsInCategory(categoryId))
            {
                return;
            }
            Categories.RemoveAll(x => x.Id == categoryId);
        }

        public void RemoveAllCategories()
        {
            Categories.RemoveAll(x => x.BookId == Id);
        }

        private bool IsInCategory(Guid categoryId)
        {
            return Categories.Any(c => c.CategoryId == categoryId);
        }
    }
}
