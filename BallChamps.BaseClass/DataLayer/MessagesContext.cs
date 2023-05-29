using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.BallChamps
{
    public class MessagesContext : DbContext
    {
        public MessagesContext(DbContextOptions<MessagesContext> options) : base(options)
        {

        }
        public DbSet<Messages> Messages { get; set; }
    }
}
