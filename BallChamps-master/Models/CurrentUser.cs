using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallChamps.Models
{
    public class CurrentUser
    {
        public static string UserId { get; set; }
        public static string ProfileId { get; set; }
        public static string Token { get; set; }
        public static string UserName { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static string PasswordHash { get; set; }
        public static string SecurityStamp { get; set; }
        public static string PhoneNumber { get; set; }
        public static DateTime? LockoutEnd { get; set; }
        public static bool? LockoutEnabled { get; set; }
        public static int? AccessFailedCount { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string City { get; set; }
        public static string State { get; set; }
        public static string Zip { get; set; }
        public static string SignUpDate { get; set; }
        public static string LastLoginDate { get; set; }
        public static string Role { get; set; }
        public static string AccessLevel { get; set; }
    }
}
