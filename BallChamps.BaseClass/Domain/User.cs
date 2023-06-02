using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallChamps.Domain
{
    public partial class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("userId")]
        public string? UserId { get; set; }

        [JsonProperty("profileId")]
        public string? ProfileId { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("passwordHash")]
        public string? PasswordHash { get; set; }

        [JsonProperty("securityStamp")]
        public string? SecurityStamp { get; set; }

        [JsonProperty("lockoutEnd")]
        public string? LockoutEnd { get; set; } // changed to string because of the DB error of data

        [JsonProperty("lockoutEnabled")]
        public string? LockoutEnabled { get; set; }  // changed to string because of the DB error of data

        [JsonProperty("accessFailedCount")]
        public int? AccessFailedCount { get; set; }

        [JsonProperty("signUpDate")]
        public DateTime? SignUpDate { get; set; }

        [JsonProperty("lastLoginDate")]
        public DateTime? LastLoginDate { get; set; }

        [JsonProperty("role")]
        public string? Role { get; set; }

        [JsonProperty("resetCode")]
        public string? ResetCode { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("accessLevel")]
        public string? AccessLevel { get; set; }

    }
}
