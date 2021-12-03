using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/utils")]
    public class UtilsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UtilsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("CreateAdminUser")]
        public async Task<IActionResult> CreateAdminUser(string email, string password)
        {
            var user = new IdentityUser()
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
                return Ok();
            return BadRequest(result.Errors);
        }
    }
}