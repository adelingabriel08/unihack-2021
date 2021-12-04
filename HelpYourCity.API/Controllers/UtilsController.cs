using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using AutoMapper;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/utils")]
    public class UtilsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IStripeService _stripeService;
        private readonly IMapper _mapper;
        public UtilsController(UserManager<IdentityUser> userManager,IEmailService emailService, IStripeService stripeService, IMapper mapper)
        {
            _userManager = userManager;
            _emailService = emailService;
            _stripeService = stripeService;
            _mapper = mapper;
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

        [HttpPost("EmailService")]
        public async Task<IActionResult> SendEmail(string email,string subject,string htmlMessage)
        {
           await _emailService.SendEmailAsync(email, subject, htmlMessage);
           return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStripeProduct(GoalViewModel goalVm)
        {
            var goal = _mapper.Map<Goal>(goalVm);
            await _stripeService.AddProductToStripe(goal);
            return Ok();
        }
    }
}