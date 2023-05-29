using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class AdminSettings
    {
        [Key]
        public string AdminSettingsId { get; set; }
        public string AndroidInstallURL { get; set; }
        public string AndroidVersion { get; set; }
        public string AndroidUpdate { get; set; }
        public string IOSInstallURL { get; set; }
        public string IOSVersion { get; set; }
        public string IOSUpdated { get; set; }
        public string StagingAPIURL { get; set; }
        public string ProductionAPIURL { get; set; }
        public string BallChampsWebSiteURL { get; set; }
        public string BallChampsAdminURL { get; set; }
        public string ProjectManagementURL { get; set; }
        public string YouTubeURL { get; set; }
        public string InstagramURL { get; set; }
        public string InstagramHandle { get; set; }
        public string InstagramPassword { get; set; }
        public string BallChampsEmail { get; set; }
        public string BallChampsEmailPassword { get; set; }
        
    }
}
