using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;
using HelpYourCity.Persistence.EF;

namespace HelpYourCity.Persistence.Services
{
    public class ProposalService: Repository<Proposal>,IProposalService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGoalService _goalService;
        private readonly IMapper _mapper;

        public ProposalService(ApplicationDbContext dbContext, IGoalService goalService, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _goalService = goalService;
            _mapper = mapper;
        }

        public async Task<Proposal> AddProposal(ProposalViewModel proposalVm)
        {
            var proposalGoal = _mapper.Map<Goal>(proposalVm.Goal);
            proposalGoal.CreatedAtTime = DateTime.Now;
            proposalGoal.Slug = GenerateSlug(proposalGoal.Title);
            
            var goalEntry = await _goalService.AddOne(proposalGoal); 
            
            var proposal = _mapper.Map<Proposal>(proposalVm);
            proposal.Goal = null;
            proposal.GoalId = goalEntry.Id;
            


            var proposalEntry = await base.AddOne(proposal);
            
            return proposalEntry;
        }
        
        public string GenerateSlug(string phrase)
        {
            string str = phrase.ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", ""); // invalid chars          
            str = Regex.Replace(str, @"\s+", " ").Trim(); // convert multiple spaces into one space  
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim(); // cut and trim it  
            str = Regex.Replace(str, @"\s", "-"); // hyphens  

            return str;
        } 
    }
}