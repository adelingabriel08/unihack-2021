using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using Stripe;

namespace HelpYourCity.Persistence.Services
{
    public class StripeService : IStripeService
    {
        public async Task AddProductToStripe(Goal goal)
        {
            var options = new ProductCreateOptions
            {
                Name = goal.Title,
                Active = true,
                Caption = goal.ShortDescription,
                Images = new List<string>(){"https://www.thespruce.com/thmb/tClzdZVdo_baMV7YA_9HjggPk9k=/4169x2778/filters:fill(auto,1)/the-difference-between-trees-and-shrubs-3269804-hero-a4000090f0714f59a8ec6201ad250d90.jpg"}
            };

            var service = new ProductService();
            var product = await service.CreateAsync(options);
            Console.WriteLine(product.ToJson());
        }
    }
}