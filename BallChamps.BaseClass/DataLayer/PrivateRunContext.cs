using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class PrivateRunContext : DbContext
    {
        public PrivateRunContext(DbContextOptions<PrivateRunContext> options) : base(options)
        {

        }
        public DbSet<PrivateRun> PrivateRun { get; set; }
    }
}
