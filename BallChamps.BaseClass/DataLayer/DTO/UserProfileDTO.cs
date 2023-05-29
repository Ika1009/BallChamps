

namespace DataLayer.DTO
{
    public class UserProfileDTO
    {
        //User
        public string UserId { get; set; }        
        public string Email { get; set; }       
        public DateTime SignUpDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string AccessLevel { get; set; }

        //UserProfile
        
        public string UserProfileId { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Age { get; set; }
        public string SkillOne { get; set; }
        public string SkillTwo { get; set; }
        public string StyleOfPlay { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Height { get; set; }
        public string Sex { get; set; }
        public string ImagePath { get; set; }
        public decimal WinPercentage { get; set; }
        public string UserLevel { get; set; }
        public int PlayerRank { get; set; }
        public string UserProfileNumber { get; set; }
        public DateTime DOB { get; set; }
        public string ImageName { get; set; }
        public int TotalPointsEarned { get; set; }
        public string UserLevelImage { get; set; }
        public string StarRatingImage { get; set; }
        public int StarRating { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool HasImage { get; set; }

        //UserSettings
        public bool Comments { get; set; }
        public bool Stats { get; set; }
        public bool EmailNotifications { get; set; }

        //PlayerInvite
       
        public string PrivateRunStatus { get; set; }

    
        public string PlayerInviteId { get; set; }
        public string PrivateRunId { get; set; }
        
        public string Status { get; set; }
        public string PlayerInviteNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReserveCourtId { get; set; }

        //
      
    }
}
