using Autofac;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using StackOverflow.Application.Utilities;
using StackOverflow.Infrastructure.Membership;
using StackOverflow.Web.Models.AccountModels;
using System.Text;
using System.Text.Encodings.Web;
using LoginModel = StackOverflow.Web.Models.AccountModels.LoginModel;
using RegisterModel = StackOverflow.Web.Models.AccountModels.RegisterModel;

namespace StackOverflow.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
		private readonly ILogger<AccountController> _logger;
		private readonly ILifetimeScope _scope;
		private UserManager<ApplicationUser> _userManager;
		private SignInManager<ApplicationUser> _signInManager;
		private IEmailService _emailService;

		public AccountController(ILogger<AccountController> logger, ILifetimeScope scope,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IEmailService emailService)
        {
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_scope = scope ?? throw new ArgumentNullException(nameof(scope));
			_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
			_signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
			_emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
		}

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { email = user.Email, code = code }, 
                        protocol: HttpContext.Request.Scheme);

					await _emailService.SendSingleEmail(model.Email, model.Email, "Confirm your email",
					$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if(_userManager.Options.SignIn.RequireConfirmedEmail)
                    {
						return RedirectToAction("RegisterConfirmation", new { email = model.Email });
					}
					else
                    {
						await _signInManager.SignInAsync(user, isPersistent: false);
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
					return View(model);
				}
			}
            return View(model);
        }

        public async Task<IActionResult> Login()
        {
			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			var model = new LoginModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if(user != null && !user.EmailConfirmed)
				{
					ModelState.AddModelError(string.Empty, "Email not confirmed yet.");
					return View(model);
				}

				var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				}
			}
			return View(model);
        }

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout(string returnUrl = null)
		{
			await _signInManager.SignOutAsync();

			if (returnUrl != null)
			{
				return LocalRedirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public IActionResult RegisterConfirmation(string email)
        {
			return View();
		}

		public async Task<IActionResult> ConfirmEmail(string email, string code)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user == null)
			{
				return RedirectToAction("Error", "Home");
			}
			var decodedCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
			var result = await _userManager.ConfirmEmailAsync(user, decodedCode);
			if (result.Succeeded)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Error", "Home");
			}
		}
    }
}
