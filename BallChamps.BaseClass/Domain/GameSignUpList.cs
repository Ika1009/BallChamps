using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class GameSignUpList
    {
        [Key]
        public string GameSignUpListId { get; set; }
        public string CourtId { get; set; }
        public string GameSignUpListString { get; set; }
        public string Winners { get; set; }
        public string GameEndedDateTime { get; set; }
        public string GameStartDateTime { get; set; }
    }
}
