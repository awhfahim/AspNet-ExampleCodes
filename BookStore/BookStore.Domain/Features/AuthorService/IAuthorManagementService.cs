using BookStore.Domain.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Features.AuthorService
{
	public interface IAuthorManagementService
	{
		Task<ICollection<Author>> GetAuthorsAsync();
	}
}
