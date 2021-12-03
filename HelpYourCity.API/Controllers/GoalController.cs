using System.Collections;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("Goals")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _goalService.GetPublishedGoals();
            return Ok(response);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetOne(string slug)
        {
            var response = await _goalService.GetGoalBySlug(slug);
            return Ok(response);
        }
        
    }
}