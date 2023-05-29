using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class NewsFeedLikeContext : DbContext
    {
        public NewsFeedLikeContext(DbContextOptions<NewsFeedLikeContext> options) : base(options)
        {

        }
        public DbSet<NewsFeedLike> NewsFeedLike { get; set; }
    }
}
