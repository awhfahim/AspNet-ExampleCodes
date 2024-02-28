using Autofac;
using CustomizingIdentityFramework.Infrastructure.Membership;
using CustomizingIdentityFramework.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CustomizingIdentityFramework.Web.Controllers
{
    public class AccountController(ILogger<AccountController> _logger, ILifetimeScope _scope,
        RoleManager<ApplicationRole> _roleManager) : Controller
    {
        public IActionResult Register()
        {
            var model = _scope.Resolve<RegistrationModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                var response = await model.OnPostAsync(Url.Content("~/"));

                if (response.errors is not null)
                {
                    foreach (var error in response.errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                    return Redirect(response.redirectLocation);
            }

            return View(model);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                var response = await model.OnPostAsync();
                return Redirect(response.ToString()!);
            }
            return View();
        }

        [Authorize(Policy = "CourseViewPolicy")]
        public IActionResult CreateUser()
        {
            return View(User);
        }

        public async Task<IActionResult> CreateRole()
        {
            await _roleManager.CreateAsync(new ApplicationRole { Name = "Admin"});
            await _roleManager.CreateAsync(new ApplicationRole { Name = "SuperAdmin"});
            await _roleManager.CreateAsync(new ApplicationRole { Name = "User"});
            await _roleManager.CreateAsync(new ApplicationRole { Name = "Supervisor"});
           // await _roleManager.
            //new Claim("UpdateCourse", "true");
            return View();
        }
    }
}
