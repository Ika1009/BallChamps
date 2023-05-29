using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CourtWaitingListContext : DbContext
    {
        public CourtWaitingListContext(DbContextOptions<CourtWaitingListContext> options) : base(options)
        {

        }
        public DbSet<CourtWaitingList> CourtWaitingList { get; set; }
    }
}
