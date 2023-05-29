using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string Image { get; set; }
        public string VideoURL { get; set; }
        public string CreatedDate { get; set; }
    }
}
