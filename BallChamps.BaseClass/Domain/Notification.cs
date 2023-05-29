using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Notification
    {
        [Key]
        public string NotificationId { get; set; }
        public string UserProfileId { get; set; }
        public string CampaignId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
        public string DisplayTo { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImagePath { get; set; }
    }
}
