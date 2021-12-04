﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;
using HelpYourCity.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Stripe;

namespace HelpYourCity.Persistence.Services
{
    public class StripeService : IStripeService
    {
        private readonly IGoalService _goalService;
        private readonly IConfiguration _configuration;
        private readonly IRepository<Donor> _donorRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly ApplicationDbContext _dbContext;

        public StripeService(IGoalService goalService, 
            IConfiguration configuration, 
            IRepository<Donor> donorRepository,
            IRepository<Payment> paymentRepository,
            ApplicationDbContext dbContext)
        {
            _goalService = goalService;
            _configuration = configuration;
            _donorRepository = donorRepository;
            _paymentRepository = paymentRepository;
            _dbContext = dbContext;
        }
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

        public async Task<PaymentOptions> GetPaymentOptions(PaymentRequestViewModel paymentVm)
        {
            var goal = await _goalService.GetGoalWithImageById(paymentVm.GoalId);
            if (goal is null)
                return null;

            if (String.IsNullOrWhiteSpace(goal.StripePriceCorrelationId))
                return null;

            var donor = new Donor()
            {
                FirstName = paymentVm.FirstName,
                LastName = paymentVm.LastName,
                CreatedAtTime = DateTime.Now,
                Email = paymentVm.Email,
                GoalId = paymentVm.GoalId,
                IsAnnonymous = paymentVm.IsAnnonymous,
                Message = paymentVm.Message,
                Quantity = paymentVm.Quantity
            };
            var donorEntry = await _donorRepository.AddOne(donor);
            
            return new PaymentOptions()
            {
                SuccessUrl = _configuration["Stripe:SuccessUrl"],
                CancelUrl = _configuration["Stripe:CancelUrl"],
                CustomerEmail = paymentVm.Email,
                LineItems = new List<object>(){new {Price = goal.StripePriceCorrelationId, Quantity = paymentVm.Quantity}},
                Mode = "payment",
                SubmitType = "pay"
            };
        }
        public async Task ProcessPaymentSucceeded(Event stripeEvent)
        {
            var customer = stripeEvent.Data.Object as Customer;
            var payment = new Payment()
            {
                EventId = stripeEvent.Id,
                RequestId = stripeEvent.Request.Id,
                Email = customer.Email,
                FullName = customer.Name
            };
            var paymentEntity = await _paymentRepository.AddOne(payment);

            var donor = await _dbContext.Donors.FirstOrDefaultAsync(p => p.Email == payment.Email);

            donor.PaymentId = paymentEntity.Id;
            await _dbContext.SaveChangesAsync();

        }
    }
}