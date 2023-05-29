using System.ComponentModel.DataAnnotations;
namespace BallChamps.Domain

{
    public class Blog
    {
        [Key]
        public string BlogId { get; set; }
        public string BlogNumber { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
        public DateTime PostDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public string ImagePath { get; set; }
    }
}
