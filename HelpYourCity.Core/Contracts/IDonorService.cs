using System.Collections.Generic;
using System.Threading.Tasks;
using HelpYourCity.Core.Entities;

namespace HelpYourCity.Core.Contracts
{
    public interface IDonorService:IRepository<Donor>
    {
        public Task<List<Donor>> getAllDonorsForAGoal(int id);
        public Task<long> getQuantityForDonors(int id);
    }
}