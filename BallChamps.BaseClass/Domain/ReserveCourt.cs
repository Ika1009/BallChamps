using System.ComponentModel.DataAnnotations;


namespace BallChamps.Domain
{
    public class ReserveCourt
    {
        [Key]
        public string ReserveCourtId { get; set; }
        public string CourtId { get; set; }
        public string HostUserProfileId { get; set; }
        public string AvailableTimes { get; set; }
        public string ReserveDay { get; set; }
        public string ReserveCourtNumber { get; set; }
        public string Status { get; set; }
        public int PlayerLimit { get; set; }
        public int PerPlayerCost { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

    }
}
