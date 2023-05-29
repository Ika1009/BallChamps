using System.ComponentModel.DataAnnotations;
namespace BallChamps.Domain

{
    public class CourtPrivateRunAvailability
    {
        [Key]
        public string CourtPrivateRunAvailabilityId { get; set; }
        public string CourtId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        
    }
}
