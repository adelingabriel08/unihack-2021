using System.Threading.Tasks;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;

namespace HelpYourCity.Core.Contracts
{
    public interface IProposalService : IRepository<Proposal>
    {
        Task<Proposal> AddProposal(ProposalViewModel proposalVm);
    }
}