using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public partial class Followers
    {
        [Key]
        public string FollowersId { get; set; }
        public string UserProfileId { get; set; }
        public string FollowedByUserProfileId { get; set; }

    }
}
