using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class NewsFeed
    {
        [Key]
        public string? NewsFeedId { get; set; }
        public string? NewsFeedNumber { get; set; }
        public DateTime? PostedDate { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? ObjType { get; set; }
        public string? ImagePath { get; set; }
        public int? Likes { get; set; }
        public string? VideoURL { get; set; }
        public string? URL { get; set; }
    }
}
