using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PlayerHistoryContext : DbContext
    {
        public PlayerHistoryContext(DbContextOptions<PlayerHistoryContext> options) : base(options)
        {

        }
        public DbSet<PlayerHistory> PlayerHistory { get; set; }
    }
}
