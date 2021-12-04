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
        public async Task<string> AddProductToStripe(Goal goal)
        {
            var productOptions = new ProductCreateOptions
            {
                Name = goal.GoalItemName,
                Active = true,
                Description = goal.ShortDescription,
                Images = new List<string>(){"https://www.thespruce.com/thmb/tClzdZVdo_baMV7YA_9HjggPk9k=/4169x2778/filters:fill(auto,1)/the-difference-between-trees-and-shrubs-3269804-hero-a4000090f0714f59a8ec6201ad250d90.jpg"}
            };

            var productService = new ProductService();
            var product = await productService.CreateAsync(productOptions);

            var priceOptions = new PriceCreateOptions()
            {
                Active = true,
                BillingScheme = "per_unit",
                Currency = "eur",
                Nickname = "PricePerUnit",
                Product = product.Id,
                UnitAmount = goal.PricePerUnit*100 
                // multiplied because we do not have floating prices
            };
            var priceService = new PriceService();
            var price = await priceService.CreateAsync(priceOptions);
            return product.Id;
        }
    }
}