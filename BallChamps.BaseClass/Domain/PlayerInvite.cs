using System.ComponentModel.DataAnnotations;
namespace BallChamps.Domain

{
    public class PlayerInvite
    {
        [Key]
        public string PlayerInviteId { get; set; }
        public string PrivateRunId { get; set; }
        public string HostUserProfileId { get; set; }
        public string PlayerInviteNumber { get; set; }      
        public string UserProfileId { get; set; }
        public string Status { get; set; }
        public string ReserveCourtId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
