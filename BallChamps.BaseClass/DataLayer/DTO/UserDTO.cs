

namespace DataLayer.DTO
{
    public class UserDTO
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
        public string PlayerNumber { get; set; }
        public string DOB { get; set; }
        public string ImageName { get; set; }
        public int TotalPointsEarned { get; set; }
        public string UserLevelImage { get; set; }
        public string StarRatingImage { get; set; }
        public int StarRating { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool EnableComments { get; set; }



    }
}
