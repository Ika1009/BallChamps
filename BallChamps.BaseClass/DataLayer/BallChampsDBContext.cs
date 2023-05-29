using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public partial class BallChampsDBContext : DbContext
    {
        public BallChampsDBContext()
        {
        
        }

        public BallChampsDBContext(DbContextOptions<BallChampsDBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Court> Court { get; set; }       
        public virtual DbSet<AdminSettings> AdminSettings { get; set; }
        public virtual DbSet<User> User { get; set; }      
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Followers> Followers { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Rule> Rule { get; set; }
        public virtual DbSet<GameDetail> GameDetail { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }      
        public virtual DbSet<CourtWaitingList> CourtWaitingList { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<GameHistory> GameHistory { get; set; }
        public virtual DbSet<Inbox> Inbox { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Squad> Squad { get; set; }
        public virtual DbSet<NewsFeed> NewsFeed { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<NewsFeedLike> NewsFeedLike { get; set; }
        public virtual DbSet<UserSetting> UserSetting { get; set; }
        public virtual DbSet<CourtPlayerBet> CourtPlayerBet { get; set; }
        public virtual DbSet<PrivateRun> PrivateRun { get; set; }
        public virtual DbSet<CourtPrivateRunAvailability> CourtPrivateRunAvailability { get; set; }
        public virtual DbSet<PlayerInvite> PlayerInvite { get; set; }
        public virtual DbSet<PlayerHistory> PlayerHistory { get; set; }
        public virtual DbSet<ReserveCourt> ReserveCourt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=184.168.194.53;database=BallChamps_Staging;User ID=UserXcel_Admin;Password=aB0@m5h9");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //modelBuilder.Entity<UserProfile>().Ignore(t => t.Image);
        //    modelBuilder.Entity<BC_User>()
        //    .Property(e => e.BC_UserId);
           
           
           
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
