using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Rule
    {
        [Key]
        public string RuleId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string PointsToAdd { get; set; }
        
    }
}
