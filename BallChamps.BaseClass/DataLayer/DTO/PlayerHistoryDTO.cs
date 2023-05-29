

namespace DataLayer.DTO
{
    public class PlayerHistoryDTO
    {

        public string GameNumber { get; set; }
        public string CourtId { get; set; }
        public string WinningTeam { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PlayerHistoryId { get; set; }
        public string WinOrLose { get; set; }
        public string UserProfileId { get; set; }
        public string GameHistoryId { get; set; }
        public string CourtName { get; set; }

    }
}
