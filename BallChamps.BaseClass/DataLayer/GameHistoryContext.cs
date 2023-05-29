using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GameHistoryContext : DbContext
    {
        public GameHistoryContext(DbContextOptions<GameHistoryContext> options) : base(options)
        {

        }
        public DbSet<GameHistory> GameHistory { get; set; }
    }
}
