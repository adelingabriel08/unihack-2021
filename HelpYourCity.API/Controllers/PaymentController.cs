using System;
using System.IO;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public PaymentController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }
        
        [HttpPost("webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], "whsec_gb0iDbJdsAUppA0F7RDh9W4wHQMQxfQ5");

                // Handle the event
                if (stripeEvent.Type == Events.CustomerCreated)
                {
                    await _stripeService.ProcessPaymentSucceeded(stripeEvent);
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }

        [HttpPost("GetOptions")]
        public async Task<IActionResult> GetPaymentOptions(PaymentRequestViewModel paymentVm)
        {
            var result = await _stripeService.GetPaymentOptions(paymentVm);

            if (result is null)
                return BadRequest();
            
            return Ok(result);
        }
    }
}