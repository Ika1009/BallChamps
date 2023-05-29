

namespace DataLayer.DTO
{
    public class CommentDTO
    {
        public string CommentId { get; set; }
        public string QuickComment { get; set; }
        public string Message { get; set; }
        public string UserProfileId { get; set; }
        public string ImagePath { get; set; }
        public int StarRating { get; set; }
        public string UserName { get; set; }
        public bool HasImage { get; set; }
        public string CommentedByUserProfileId { get; set; }
        public DateTime CommentDate { get; set; }


    }
}
