using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using StackOverflow.Application.Utilities;
using StackOverflow.Infrastructure.Membership;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Security.Policy;

namespace StackOverflow.Web.Models.AccountModels
{
    public class RegisterModel
    {

		[Required, EmailAddress, Display(Name = "Email")]
		public string Email { get; set; }

		[Required, Display(Name = "Password"), DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		public string Password { get; set; }

		public string? ReturnUrl { get; set; }
		public RegisterModel() { }


		//internal async Task<(IEnumerable<IdentityError>? errors, string? redirectLocation)> RegisterAsync()
		//{
		//	//ReturnUrl ??= urlPrefix;

		//	var user = new ApplicationUser { UserName = Email, Email = Email };
		//	var result = await _userManager.CreateAsync(user, Password);
		//	if (result.Succeeded)
		//	{
		//		//await _userManager.AddToRoleAsync(user, "Supervisor");
		//		//await _userManager.AddToRoleAsync(user, "Admin");

		//		//await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("UpdateCourse", "true"));
		//		//await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("ViewCourse", "true"));

		//		var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
		//		code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
		//		var callbackUrl = $"https://localhost:7055/AccountManagement/Account/ConfirmEmail?email={user.Email}&code={code}";
				

		//		_emailService.SendSingleEmail(Email, Email, "Confirm your email",
		//			$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

		//		if (_userManager.Options.SignIn.RequireConfirmedAccount)
		//		{
		//			var confirmationPageLink = $"RegisterConfirmation?email={Email}";
		//			return (null, confirmationPageLink);
		//		}
		//		else
		//		{
		//			await _signInManager.SignInAsync(user, isPersistent: false);
		//			return (null, ReturnUrl);
		//		}
		//	}
		//	else
		//	{
		//		return (result.Errors, null);
		//	}
		//}

		//internal void Resolve(ILifetimeScope scope)
		//{
		//	_userManager = scope.Resolve<UserManager<ApplicationUser>>();
		//	_signInManager = scope.Resolve<SignInManager<ApplicationUser>>();
		//	_emailService = scope.Resolve<IEmailService>();
		//}
	}
}
