using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace HelpYourCity.Persistence.Services
{
    public class EventsService: Repository<VolunteeringEvent>,IEventsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGoalService _goalService;

        public EventsService(ApplicationDbContext dbContext,IGoalService goalService) : base(dbContext)
        {
            _dbContext = dbContext;
            _goalService = goalService;
        }

        public async Task<List<VolunteeringEvent>> getAllEventsForAGoal(int id)
        {
            var events =await _dbContext.VolunteeringEvents.Where(p => p.GoalId == id).OrderByDescending(p=>p.StartTime).ToListAsync();
            return events;
        }
    }
}