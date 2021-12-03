using Microsoft.EntityFrameworkCore;

namespace HelpYourCity.Persistence.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}