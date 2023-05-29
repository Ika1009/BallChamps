using System.ComponentModel.DataAnnotations;
namespace BallChamps.Domain

{
    public class PrivateRun
    {
        [Key]
        public string PrivateRunId { get; set; }
        public string CourtId { get; set; }
        public string HostUserProfileId { get; set; }
        public int PerPersonCost { get; set; }
        public int PlayerLimit { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
