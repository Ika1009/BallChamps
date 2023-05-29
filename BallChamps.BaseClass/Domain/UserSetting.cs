using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class UserSetting
    {
        [Key]
        public string? UserSettingId { get; set; }
        public bool? Comments { get; set; }
        public bool? Stats { get; set; }
        public bool? EmailNotifications { get; set; }

    }
}
