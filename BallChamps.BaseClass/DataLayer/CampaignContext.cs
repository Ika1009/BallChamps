using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CampaignContext : DbContext
    {
        public CampaignContext(DbContextOptions<CampaignContext> options) : base(options)
        {

        }
        public DbSet<Campaign> Campaign { get; set; }
    }
}
