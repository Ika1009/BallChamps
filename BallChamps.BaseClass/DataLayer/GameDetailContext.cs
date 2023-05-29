using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GameDetailContext : DbContext
    {
        public GameDetailContext(DbContextOptions<GameDetailContext> options) : base(options)
        {

        }
        public DbSet<GameDetail> GameDetail { get; set; }
    }
}
