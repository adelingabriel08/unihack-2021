using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace HelpYourCity.Persistence.Services
{
    public class GoalService : Repository<Goal>, IGoalService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IStripeService _stripeService;

        public GoalService(ApplicationDbContext dbContext, IStripeService stripeService) : base(dbContext)
        {
            _dbContext = dbContext;
            _stripeService = stripeService;
        }

        public async Task<List<Goal>> GetPublishedGoals()
        {
            var goals = await _dbContext.Goals.Where(p => p.IsPublished == true).ToListAsync();
            foreach (var goal in goals)
            {
                var numberOfDonations = await _dbContext.Donors
                    .Where(p => p.GoalId == goal.Id)
                    .Where(p => p.PaymentId != null && p.PaymentId > 0)
                    .OrderByDescending(p => p.CreatedAtTime)
                    .SumAsync(p => p.Quantity);

                goal.NumberOfDonations = numberOfDonations;
            }

            return goals;
        }

        public async Task<Goal> GetGoalBySlug(string slug)
        {
            var item = await _dbContext.Goals.Where(p => p.IsPublished == true)
                .FirstOrDefaultAsync(p => p.Slug == slug);
            if(item != null)
                item.NumberOfDonations = await _dbContext.Donors
                    .Where(p => p.GoalId == item.Id)
                    .Where(p => p.PaymentId != null && p.PaymentId > 0)
                    .OrderByDescending(p => p.CreatedAtTime)
                    .SumAsync(p => p.Quantity);
            return item;
        }

        public async Task<Goal> GetGoalWithImageById(int goalId)
        {
            return await _dbContext.Goals.Include(g => g.Image).SingleOrDefaultAsync(g => g.Id == goalId);
        }

        public async Task EditGoal(Goal goal)
        {
            var id = goal.Id;
            var goalToModify = await GetOne(id);

            var published = goal.IsPublished && !goalToModify.IsPublished;
            goalToModify.Description = goal.Description;
            goalToModify.Title = goal.Title;
            goalToModify.ShortDescription = goal.Title;
            goalToModify.Target = goal.Target;
            goalToModify.GoalItemName = goal.GoalItemName;
            goalToModify.PricePerUnit = goal.PricePerUnit;
            goalToModify.IsPublished = goal.IsPublished;
            if (published)
            {
                var stripePriceId = await _stripeService.AddProductToStripe(goalToModify);
                goalToModify.StripePriceCorrelationId = stripePriceId;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}