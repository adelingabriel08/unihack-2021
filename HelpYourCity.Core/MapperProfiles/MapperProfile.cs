using AutoMapper;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;

namespace HelpYourCity.Core.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GoalViewModel, Goal>();
            CreateMap<Goal, GoalViewModel>();
            CreateMap<Proposal, ProposalViewModel>();
            CreateMap<ProposalViewModel, Proposal>();
        }
    }
}