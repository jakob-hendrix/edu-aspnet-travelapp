using AspTravelerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspTravelerApp.Data
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
            Database.EnsureCreatedAsync().Wait();
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Segment> Segments { get; set; }
    }
}
