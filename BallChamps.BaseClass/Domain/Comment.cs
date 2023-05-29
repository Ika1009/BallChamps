using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallChamps.Domain
{
    public class Comment
    {
        [Key]
        public string CommentId { get; set; }
        public string UserProfileId { get; set; }
        public string CommentedByUserProfileId { get; set; }
        public string Message { get; set; }
        public int StarRating { get; set; }
        public string QuickComment { get; set; }
        public string UserName { get; set; }
        public string StarRatingImage { get; set; }
        public DateTime CommentDate { get; set; }

        [NotMapped]
        public string ImagePath { get; set; }

    }
}
