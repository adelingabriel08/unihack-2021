using System.Collections.Generic;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities.Base;
using HelpYourCity.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace HelpYourCity.Persistence.Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public virtual async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetOne(int itemId)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(p => p.Id == itemId);
        }

        public virtual async Task<T> AddOne(T item)
        {
            var entry = await _dbContext.Set<T>().AddAsync(item);

            await _dbContext.SaveChangesAsync();
            
            return entry.Entity;
        }

        public virtual async Task Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}