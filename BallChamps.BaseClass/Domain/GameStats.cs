using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class GameStats
    {
        [Key]
        public string GameStatsId { get; set; }      
        public string UserProfileId { get; set; }
        public string CourtId { get; set; }
        public string WinOrLose { get; set; }
        public string GameDate { get; set; }

    }
}
