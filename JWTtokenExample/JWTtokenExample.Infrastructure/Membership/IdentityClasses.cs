using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTtokenExample.Infrastructure.Membership
{
	//Application User 
	public class ApplicationUser : IdentityUser
	{
		public virtual ICollection<ApplicationUserClaim>? Claims { get; set; }
		public virtual ICollection<ApplicationUserLogin>? Logins { get; set; }
		public virtual ICollection<ApplicationUserToken>? Tokens { get; set; }
		public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpiryTime { get; set; }
	}

	//Application Roles 
	public class ApplicationRoles : IdentityRole
	{
		public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
		public virtual ICollection<ApplicationRoleClaim>? RoleClaims { get; set; }
	}

	//Application UserRole 
	public class ApplicationUserRole : IdentityUserRole<string>
	{
		public virtual ApplicationUser? User { get; set; }
		public virtual ApplicationRoles? Role { get; set; }
	}

	//These classes are not so important when you doing asp.net core identity with single project but here I am creating class library therefore I have added these classes. 
	// ApplicationUserLogin 
	public class ApplicationUserLogin : IdentityUserLogin<string>
	{
		public virtual ApplicationUser User { get; set; }
	}

	// ApplicationUserClaim 
	public class ApplicationUserClaim : IdentityUserClaim<string>
	{
		public virtual ApplicationUser User { get; set; }
	}

	//ApplicationUserToken 
	public class ApplicationUserToken : IdentityUserToken<string>
	{
		public virtual ApplicationUser User { get; set; }
	}

	//ApplicationRoleClaim 
	public class ApplicationRoleClaim : IdentityRoleClaim<string>
	{
		public virtual ApplicationRoles? Role { get; set; }
	}

}
