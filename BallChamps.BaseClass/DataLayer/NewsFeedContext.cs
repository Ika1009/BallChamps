using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.BallChamps
{
    public class NewsFeedContext : DbContext
    {
        public NewsFeedContext(DbContextOptions<NewsFeedContext> options) : base(options)
        {

        }
        public DbSet<NewsFeed> NewsFeed { get; set; }
    }
}
