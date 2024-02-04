using Autofac;
using CustomizingIdentityFramework.Infrastructure.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace CustomizingIdentityFramework.Web.Models
{
    public class LogInModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public LogInModel() { }

        public LogInModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _signInManager = scope.Resolve<SignInManager<ApplicationUser>>();
        }

        public async Task<string> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= ("~/");

            var result = await _signInManager.PasswordSignInAsync(Email, Password, RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return returnUrl;
            }
            //if (result.RequiresTwoFactor)
            //{
            //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = RememberMe });
            //}
            //if (result.IsLockedOut)
            //{
            //    _logger.LogWarning("User account locked out.");
            //    return RedirectToPage("./Lockout");
            //}
            else
            {
                return returnUrl;
            }
        }

    }
}
