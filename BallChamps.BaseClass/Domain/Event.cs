using System.ComponentModel.DataAnnotations;


namespace BallChamps.Domain
{
    public class Event
    {
        [Key]
        public string EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventDate { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string CoverArtImage { get; set; }
        public string CreatedDate { get; set; }
        public string PointCost { get; set; }
    }
}
