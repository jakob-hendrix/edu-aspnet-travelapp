using Microsoft.EntityFrameworkCore;

namespace AspTravelerApp.Models
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions < TripDbContext > options) : base(options)
        {
            Database.EnsureCreatedAsync().Wait();
        }

        public DbSet<Trip> Trips { get; set; }
    }
}
