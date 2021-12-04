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

        public GoalService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Goal>> GetPublishedGoals()
        {
            return await _dbContext.Goals.Where(p => p.IsPublished == true).ToListAsync();
        }

        public async Task<Goal> GetGoalBySlug(string slug)
        {
            var item =await  _dbContext.Goals.Where(p => p.IsPublished == true).FirstOrDefaultAsync(p => p.Slug == slug);
            return item;
        }

        public async Task<Goal> GetGoalWithImageById(int goalId)
        {
            return await _dbContext.Goals.Include(g => g.Image).SingleOrDefaultAsync(g => g.Id == goalId);
        }
    }
}