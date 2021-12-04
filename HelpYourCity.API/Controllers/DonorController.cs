using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/goals/{id}/donors")]
    public class DonorController:ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllDonorsForGoal(int id)
        {
            var response = await _donorService.getAllDonorsForAGoal(id);
            return Ok(response);
        }
    }
}