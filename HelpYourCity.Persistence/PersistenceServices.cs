using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using HelpYourCity.Persistence.EF;
using HelpYourCity.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelpYourCity.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly("HelpYourCity.API")
                ));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IGoalService,GoalService>();
            services.AddScoped<IProposalService, ProposalService>();
            services.AddScoped<IEventsService,EventsService>();
            services.AddScoped<IDonorService,DonorService>();
            services.AddScoped<IFileService,FileService>();
            services.AddScoped<IEmailService,EmailService>();
            services.AddScoped<IVolunteerService,VolunteerService>();
            
            services.AddScoped<IStripeService, StripeService>();
            return services;
        }
    }
}