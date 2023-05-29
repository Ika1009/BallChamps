using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PlayerInviteContext : DbContext
    {
        public PlayerInviteContext(DbContextOptions<PlayerInviteContext> options) : base(options)
        {

        }
        public DbSet<PlayerInvite> PlayerInvite { get; set; }
    }
}
