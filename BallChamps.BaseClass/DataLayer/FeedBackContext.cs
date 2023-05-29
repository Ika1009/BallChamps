using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class FeedBackContext : DbContext
    {
        public FeedBackContext(DbContextOptions<FeedBackContext> options) : base(options)
        {

        }
        public DbSet<FeedBack> FeedBack { get; set; }
    }
}
