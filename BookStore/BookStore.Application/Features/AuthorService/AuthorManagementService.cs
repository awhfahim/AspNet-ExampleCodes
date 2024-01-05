using BookStore.Domain.Entities.Authors;
using BookStore.Domain.Features.AuthorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Features.AuthorService
{
	public class AuthorManagementService : IAuthorManagementService
	{
		private readonly IApplicationUnitOfWork _unitOfWork;
		public AuthorManagementService(IApplicationUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ICollection<Author>> GetAuthorsAsync()
		{
			return await _unitOfWork.AuthorRepository.GetAllAsync();
		}
	}
}
