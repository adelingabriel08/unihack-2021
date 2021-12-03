using HelpYourCity.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpYourCity.Persistence.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<VolunteeringEvent> VolunteeringEvents { get; set; }

    }
}