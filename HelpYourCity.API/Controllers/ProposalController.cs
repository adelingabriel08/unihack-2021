using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/proposal")]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService _proposalService;

        public ProposalController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostOne(Proposal proposal)
        {
            var response = await _proposalService.AddProposal(proposal);
            return Ok(response);
        }
        
    }
}