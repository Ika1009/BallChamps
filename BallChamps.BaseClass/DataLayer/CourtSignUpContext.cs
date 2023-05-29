using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class CourtSignUpContext : DbContext
    {
        public CourtSignUpContext(DbContextOptions<CourtSignUpContext> options) : base(options)
        {

        }
        public DbSet<CourtWaitingList> CourtSignUp { get; set; }
    }
}
