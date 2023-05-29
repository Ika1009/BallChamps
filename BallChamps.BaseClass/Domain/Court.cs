using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallChamps.Domain
{
    public partial class Court 
    {
        [Key]
        public string CourtId { get; set; }
        public string CourtNumber { get; set; }
        public string CourtName { get; set; }
        public string Address { get; set; }
        public string Rating { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ImagePath { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Description { get; set; }
        public DateTime SignUpTime { get; set; }
        public string Status { get; set; }
        public string OpenClosed { get; set; }
        public string StatusIndicatorImage { get; set; }
        public string Type { get; set; }
        public string ObjType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BetStatus { get; set; }
        public int BetCost { get; set; }
        public string AvailableTimes { get; set; }
        public decimal ReserveCost { get; set; }
        public string CourtCoordinator { get; set; }

        [NotMapped]
        public bool SignedUp { get; set; }
        [NotMapped]
        public string Distance { get; set; }


    }
}
