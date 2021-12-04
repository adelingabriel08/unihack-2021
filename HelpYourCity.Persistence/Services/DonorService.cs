using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace HelpYourCity.Persistence.Services
{
    public class DonorService:Repository<Donor>,IDonorService
    {
        private readonly ApplicationDbContext _dbContext;

        public DonorService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Donor>> getAllDonorsForAGoal(int id)
        {
            var donors = await _dbContext.Donors
                .Where(p => p.GoalId == id)
                .Where(p => p.PaymentId != null && p.PaymentId > 0)
                .OrderByDescending(p => p.CreatedAtTime)
                .Take(10)
                .ToListAsync();
            return donors;
        }
        public async Task<long> getQuantityForDonors(int id)
        {
                var donors = await _dbContext.Donors
                    .Where(p => p.GoalId == id)
                    .Where(p => p.PaymentId != null && p.PaymentId > 0)
                    .OrderByDescending(p => p.CreatedAtTime)
                    .SumAsync(p => p.Quantity);
            
            return donors;
        }
    }
}