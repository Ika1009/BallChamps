using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AdminSettingsContext : DbContext
    {
        public AdminSettingsContext(DbContextOptions<AdminSettingsContext> options) : base(options)
        {

        }

        public DbSet<AdminSettings> AdminSettings { get; set; }
    }
}
