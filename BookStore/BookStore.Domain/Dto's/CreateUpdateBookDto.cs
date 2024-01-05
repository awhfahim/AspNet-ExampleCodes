using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Dto_s
{
	public class CreateUpdateBookDto
	{
		public Guid AuthorId { get; set; }

		public string Name { get; set; }

		public DateTime PublishDate { get; set; }

		public float Price { get; set; }

		public Guid[] CategoryName { get; set; }
	}
}
