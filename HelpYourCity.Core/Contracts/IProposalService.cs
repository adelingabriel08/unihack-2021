using System.Threading.Tasks;
using HelpYourCity.Core.Entities;

namespace HelpYourCity.Core.Contracts
{
    public interface IProposalService : IRepository<Proposal>
    {
        Task<Proposal> AddProposal(Proposal proposal);
    }
}