using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class NotificationContext : DbContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options)
        {

        }
        public DbSet<Notification> Notification { get; set; }
    }
}
