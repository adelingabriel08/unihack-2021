using System.Threading.Tasks;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;

namespace HelpYourCity.Core.Contracts
{
    public interface IVolunteerService:IRepository<Volunteer>
    {
        Task<Volunteer> addVolunteer(VolunteerViewModel volunteerVM);
    }
}