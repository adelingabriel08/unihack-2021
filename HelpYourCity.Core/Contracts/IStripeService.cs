using System.Threading.Tasks;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;
using Stripe;

namespace HelpYourCity.Core.Contracts
{
    public interface IStripeService
    {
        Task<string> AddProductToStripe(Goal goal);
        Task<PaymentOptions> GetPaymentOptions(PaymentRequestViewModel paymentVm);
        Task ProcessPaymentSucceeded(Event stripeEvent);
    }
}