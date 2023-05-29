

namespace DataLayer.DTO
{
    public class ReserveCourtDTO
    {
        public string FollowedByUserProfileId { get; set; }
        public string ReserveCourtId { get; set; }
        public string CourtId { get; set; }
        public string HostUserProfileId { get; set; }
        public string AvailableTimes { get; set; }
        public string ReserveDay { get; set; }
        public string ReserveCourtNumber { get; set; }
        public string Status { get; set; }
        public string CourtName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Rating { get; set; }
        public string ImagePath { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime SignUpTime { get; set; }
        public string StatusIndicatorImage { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CourtNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OpenClosed { get; set; }
        public string ObjType { get; set; }
        public string BetStatus { get; set; }
        public int BetCost { get; set; }
        public decimal ReserveCost { get; set; }
        public string CourtCoordinator { get; set; }
        public int PerPlayerCost { get; set; }
        public int PerPersonCost { get; set; }
        public int PlayerLimit { get; set; }
        public string Title { get; set; }
        public string PrivateRunId { get; set; }
        public string PR_Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ReserveDate { get; set; }

        //UserProfile Table
        public string UserProfileNumber { get; set; }

    }
}
