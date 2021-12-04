using System.Collections.Generic;
using System.Threading.Tasks;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.Entities.Base;

namespace HelpYourCity.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetOne(int itemId);
        Task<T> AddOne(T item);
        Task Delete(T item);
    }
}