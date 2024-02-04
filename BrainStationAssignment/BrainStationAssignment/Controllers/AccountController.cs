using BrainStationAssignment.Data;
using BrainStationAssignment.Membership;
using BrainStationAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrainStationAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(ApplicationDbContext _dbContext, SignInManager<ApplicationUser> _signInManager,
        UserManager<ApplicationUser> _userManager, IUserStore<ApplicationUser> _userStore) : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost("register")]
        public async Task<IActionResult> Post(UserRegistrationModel model)
        {
            if(ModelState.IsValid)
            {
                if (await _dbContext.Users.CountAsync<ApplicationUser>(x => x.UserName == model.UserName) is 0)
                {
                    var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };

                    await _userStore.SetUserNameAsync(user, model.UserName, CancellationToken.None);

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if(result.Succeeded)
                    {
                        var userId = await _userManager.GetUserIdAsync(user);
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        var response = new RegistrationResponse
                        {
                            Username = model.UserName,
                            Message = "Registration successful"
                        };
                        return Ok(response);
                    }               
                }
                else
                    return BadRequest("User Already Exists");
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
