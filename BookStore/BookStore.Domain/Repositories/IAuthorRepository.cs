using BookStore.Domain.Entities.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repositories
{
	public interface IAuthorRepository : IRepositoryBase<Author, Guid>
	{

	}
}
