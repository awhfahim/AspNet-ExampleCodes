using JWTtokenExample.Infrastructure.Membership;
using JWTtokenExample.Infrastructure.ResponseRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTtokenExample.Infrastructure.Repositories
{
	//ILoginRepository 
	public interface ILoginRepository<TUser> where TUser : ApplicationUser
	{
		Task<LoginResponseViewModel> Login(LoginRequestViewModel model);
		Task<bool> SignUp(TUser model, string password);
		Task<TokenModel> RefreshToken(TokenModel model);
	}
}
