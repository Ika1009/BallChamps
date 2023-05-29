using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class GameHistory
    {
        [Key]
        public string GameHistoryId { get; set; }
        public string GameNumber { get; set; }
        public string CourtId { get; set; }
        public string WinningTeam { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
