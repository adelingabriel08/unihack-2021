using System;
using System.Threading.Tasks;
using AutoMapper;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;
using HelpYourCity.Persistence.EF;

namespace HelpYourCity.Persistence.Services
{
    public class VolunteerService: Repository<Volunteer>,IVolunteerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VolunteerService(ApplicationDbContext dbContext,IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Volunteer> addVolunteer(VolunteerViewModel volunteerVM)
        {
            var volunteer = _mapper.Map<Volunteer>(volunteerVM);
            volunteer.CreatedAtTime = DateTime.Now;

            var volunteerEntry = await base.AddOne(volunteer);
            return volunteerEntry;
        }
    }
}