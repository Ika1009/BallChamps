using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ReserveCourtContext : DbContext
    {
        public ReserveCourtContext(DbContextOptions<ReserveCourtContext> options) : base(options)
        {

        }
        public DbSet<ReserveCourt> ReserveCourt { get; set; }
    }
}
