using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CourtPrivateRunAvailabilityContext : DbContext
    {
        public CourtPrivateRunAvailabilityContext(DbContextOptions<CourtPrivateRunAvailabilityContext> options) : base(options)
        {

        }
        public DbSet<CourtPrivateRunAvailability> CourtPrivateRunAvailability { get; set; }
    }
}
