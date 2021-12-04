using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/goals/volunteer")]
    public class VolunteerController:ControllerBase
    {
        private readonly IVolunteerService _volunteerService;

        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }

        [HttpPost]
        public async Task<IActionResult> PostVolunteer(VolunteerViewModel volunteer)
        {
            var response = await _volunteerService.addVolunteer(volunteer);
            return Ok(response);
        }


    }
}