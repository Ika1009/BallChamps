using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class RateContext : DbContext
    {
        public RateContext(DbContextOptions<RateContext> options) : base(options)
        {

        }
        public DbSet<Rate> Rate { get; set; }
    }
}
