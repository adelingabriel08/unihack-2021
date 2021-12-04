using System.Collections.Generic;
using System.Threading.Tasks;
using HelpYourCity.Core.Entities;

namespace HelpYourCity.Core.Contracts
{
    public interface IEventsService:IRepository<VolunteeringEvent>
    {
        public Task<List<VolunteeringEvent>> getAllEventsForAGoal(int id);
    }
}