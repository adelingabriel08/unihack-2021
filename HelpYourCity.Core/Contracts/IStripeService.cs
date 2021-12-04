using System.Threading.Tasks;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;

namespace HelpYourCity.Core.Contracts
{
    public interface IStripeService
    {
        Task<string> AddProductToStripe(Goal goal);
        Task<PaymentOptions> GetPaymentOptions(PaymentRequestViewModel paymentVm);
    }
}