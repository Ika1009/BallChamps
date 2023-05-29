using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class CourtPlayerBet
    {
        [Key]
        public string CourtPlayerBetId { get; set; }
        public string CourtId { get; set; }
        public string UserProfileId { get; set; }
        public DateTime BetTimeStamp { get; set; }
        public string GameHistoryId { get; set; }

    }
}
