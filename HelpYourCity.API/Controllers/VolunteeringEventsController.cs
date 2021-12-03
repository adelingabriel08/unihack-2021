using System.Collections.Generic;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/goals/{id}/events")]
    public class VolunteeringEventsController: ControllerBase
    {
        private readonly IEventsService _eventsService;

        public VolunteeringEventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }
        
        [HttpGet]
        public async Task<IActionResult> getAllEvents(int id)
        {
            var response = await _eventsService.getAllEventsForAGoal(id);
            return Ok(response);
        }
        
    }
}