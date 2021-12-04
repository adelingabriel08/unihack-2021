using System.Threading.Tasks;
using HelpYourCity.Core.Entities;

namespace HelpYourCity.Core.Contracts
{
    public interface IStripeService
    {
        Task AddProductToStripe(Goal goal);
    }
}