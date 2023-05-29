using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class OnCourtList
    {
        [Key]
        public string OnCourtId { get; set; }
        public string OnCourtString { get; set; }
        public string CourtId { get; set; }
        public string UserProfileId { get; set; }
        public string UserProfileUserName { get; set; }
        public string SignUpTime { get; set; }
       
    }
}
