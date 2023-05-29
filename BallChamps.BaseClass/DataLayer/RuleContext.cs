using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class RuleContext : DbContext
    {
        public RuleContext(DbContextOptions<RuleContext> options) : base(options)
        {

        }
        public DbSet<Rule> Rule { get; set; }
    }
}
