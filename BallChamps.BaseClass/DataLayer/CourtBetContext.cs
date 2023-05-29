using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CourtPlayerBetContext : DbContext
    {
        public CourtPlayerBetContext(DbContextOptions<CourtPlayerBetContext> options) : base(options)
        {

        }
        public DbSet<CourtPlayerBet> CourtPlayerBet { get; set; }
    }
}
