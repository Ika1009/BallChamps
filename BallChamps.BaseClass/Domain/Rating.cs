using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Rating
    {
        [Key]
        public string RatingId { get; set; }
        public string ProfileId { get; set; }
        public string UserWhosRatingProfileId { get; set; }
        public string PlayerRating { get; set; }

    }
}
