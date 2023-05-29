using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class InboxContext : DbContext
    {
        public InboxContext(DbContextOptions<InboxContext> options) : base(options)
        {

        }
        public DbSet<Inbox> Inbox { get; set; }
    }
}
