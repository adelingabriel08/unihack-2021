using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Persistence.EF;

namespace HelpYourCity.Persistence.Services
{
    public class ProposalService: Repository<Proposal>,IProposalService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGoalService _goalService;

        public ProposalService(ApplicationDbContext dbContext,IGoalService goalService) : base(dbContext)
        {
            _dbContext = dbContext;
            _goalService = goalService;
        }

        public async Task<Proposal> AddProposal(Proposal proposal)
        {
            var goal =await _goalService.AddOne(proposal.Goal);
            proposal.GoalId = goal.Id;
            proposal.Goal = null;
            var proposalEntry = await AddOne(proposal);
            return proposalEntry;
        }
    }
}