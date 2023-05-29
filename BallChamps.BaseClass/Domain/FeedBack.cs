using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class FeedBack
    {
        [Key]
        public string FeedBackId { get; set; }
        public string UserProfileId { get; set; }
        public string Message { get; set; }
        public string TimeStamp { get; set; }

    }
}
