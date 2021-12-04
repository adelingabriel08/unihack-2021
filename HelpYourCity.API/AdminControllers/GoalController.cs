using System.Diagnostics;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelpYourCity.API.AdminControllers
{
    [Authorize]
    public class GoalController : Controller
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        public async Task<IActionResult> Index()
        {
            var response =await _goalService.GetAll();
            return View(response);
        }
        
        [HttpGet]
        public async Task<ActionResult> Edit(int goalId)
        {
            var response = await _goalService.GetOne(goalId);
            return View(response);
        }
        
        [HttpPost]
        public async Task<ActionResult> Edit(Goal goal)
        {
            await _goalService.EditGoal(goal);
            return RedirectToAction(nameof(Index));

        }


    }
}