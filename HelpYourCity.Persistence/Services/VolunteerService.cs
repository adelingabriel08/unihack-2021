using System;
using System.Threading.Tasks;
using AutoMapper;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Core.ViewModels;
using HelpYourCity.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace HelpYourCity.Persistence.Services
{
    public class VolunteerService: Repository<Volunteer>,IVolunteerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public VolunteerService(ApplicationDbContext dbContext,IMapper mapper, IEmailService emailService) : base(dbContext)
        {
            _dbContext = dbContext;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<Volunteer> addVolunteer(VolunteerViewModel volunteerVM)
        {
            var volunteer = _mapper.Map<Volunteer>(volunteerVM);
            volunteer.CreatedAtTime = DateTime.Now;

            var goal = await _dbContext.Goals.FirstOrDefaultAsync(p => p.Id == volunteer.GoalId);
            var volunteeringEvent = await _dbContext.VolunteeringEvents.FirstOrDefaultAsync(p => p.Id == volunteer.EventId);

            var volunteerEntry = await base.AddOne(volunteer);
            var emailTemplate = @$"<h3>Hello {volunteer.FirstName} {volunteer.LastName}</h3>,
                    <p>Thank for your application for {goal.Title}</p>
                    <p>You applied for an event that starts in {volunteeringEvent.StartTime.Date.ToString()} 
                    and ends in {volunteeringEvent.StartTime.Date.ToString()}.</p>
                    <p>The event location is {volunteeringEvent.Location}</p>
                    <br/>
                    <p>See you there!</p>
                    <br/>
                    <p>Thank you,</p>
                    <p>Help Your City Team</p>";
            await _emailService.SendEmailAsync(volunteer.Email, "Successful volunteer application", emailTemplate);
            return volunteerEntry;
        }
    }
}