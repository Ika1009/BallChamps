using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CourtContext : DbContext
    {
        public CourtContext(DbContextOptions<CourtContext> options) : base(options)
        {

        }
        public DbSet<Court> Court { get; set; }
    }
}
