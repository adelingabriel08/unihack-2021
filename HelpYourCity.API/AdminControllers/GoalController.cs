using System;
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
        private readonly IVolunteerService _volunteerService;

        public GoalController(IGoalService goalService,IVolunteerService volunteerService)
        {
            _goalService = goalService;
            _volunteerService = volunteerService;
        }

        public async Task<IActionResult> Index()
        {
            var response =await _goalService.GetAllGoalsWithNumbers();
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

        public async Task<ActionResult> SendEmails(int id)
        {
            await _volunteerService.sendEmailsToAllVolunteers(id);
            return RedirectToAction(nameof(Index));
        }


    }
}