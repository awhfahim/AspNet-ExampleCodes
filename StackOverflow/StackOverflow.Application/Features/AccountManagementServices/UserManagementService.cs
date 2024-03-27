using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Application.Features.AccountManagementServices
{
	public class UserManagementService : IUserManagementService
	{
		private IApplicationUnitOfWork _unitOfWork;
		public UserManagementService(IApplicationUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
	}
}
