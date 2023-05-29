using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallChamps.Domain
{
    public class GameDetail
    {
        [Key]
        public string GameDetailId { get; set; }
        public string CourtId { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public string WinningTeam { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public string WinOrLose { get; set; }
        [NotMapped]
        public string CourtName { get; set; }
    }
}
