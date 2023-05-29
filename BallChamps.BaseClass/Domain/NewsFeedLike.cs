using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class NewsFeedLike
    {
        [Key]
        public string NewsFeedLikeId { get; set; }
        public string NewsFeedId { get; set; }
        public string UserProfileId { get; set; }
        public int PostLike { get; set; }
        public int PostDisLike { get; set; }

    }
}
