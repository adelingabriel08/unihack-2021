using System.Collections.Generic;
using System.Threading.Tasks;
using HelpYourCity.Core.Entities;

namespace HelpYourCity.Core.Contracts
{
    public interface IGoalService : IRepository<Goal>
    {
        Task<List<Goal>> GetPublishedGoals();

        Task<List<Goal>> GetAllGoalsWithNumbers();
        
        Task<Goal> GetGoalBySlug(string slug);
        Task<Goal> GetGoalWithImageById(int goalId);
        

        Task EditGoal(Goal goal);

    }
}