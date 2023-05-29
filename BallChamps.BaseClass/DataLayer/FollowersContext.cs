using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class FollowersContext : DbContext
    {
        public FollowersContext(DbContextOptions<FollowersContext> options) : base(options)
        {

        }
        public DbSet<Followers> Followers { get; set; }
    }
}
