using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Inbox
    {
        [Key]
        public string InboxId { get; set; }
        public string InboxImg { get; set; }        
        public string Message { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string MessageRead { get; set; }
        public string Title { get; set; }
        public string UserProfileId { get; set; }
    }
}
