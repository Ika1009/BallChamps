using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Campaign
    {
        [Key]
        public string CampaignId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CampaignNumber { get; set; }
        public string ImagePath { get; set; }
        public int Days { get; set; }
        public int Points { get; set; }
        public string Type { get; set; }
        public string ObjType { get; set; }
    }
}
