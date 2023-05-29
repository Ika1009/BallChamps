using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallChamps.Domain
{
    public partial class User 
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string? UserId { get; set; }
		public string? ProfileId { get; set; }
		public string? Token { get; set; }
		public string? Email { get; set; }
		public string? PasswordHash { get; set; }
		public string? SecurityStamp { get; set; }
		public string? LockoutEnd { get; set; }
		public string? LockoutEnabled { get; set; }
		public int? AccessFailedCount { get; set; }
		public DateTime? SignUpDate { get; set; }
		public DateTime? LastLoginDate { get; set; }
		public string? Role { get; set; }
        public string? ResetCode { get; set; }
        public string? Password { get; set; }
		public string? AccessLevel { get; set; }

	}
}
