using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities.Books
{
    public class BookWithDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate {  get; set; }
        public float Price { get; set; }
        public string AuthorName { get; set; }
        public string[] CategoryNames { get; set; }
    }
}
