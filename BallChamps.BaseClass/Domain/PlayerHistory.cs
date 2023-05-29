using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class PlayerHistory
    {
        [Key]
        public string PlayerHistoryId { get; set; }
        public string GameHistoryId { get; set; }       
        public string WinOrLose { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public string Points { get; set; }
        public string Assists { get; set; }

    }
}
