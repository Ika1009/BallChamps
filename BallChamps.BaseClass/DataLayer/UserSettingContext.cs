using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class UserSettingContext : DbContext
    {
        public UserSettingContext(DbContextOptions<UserSettingContext> options) : base(options)
        {

        }
        public DbSet<UserSetting> UserSetting { get; set; }
    }
}
