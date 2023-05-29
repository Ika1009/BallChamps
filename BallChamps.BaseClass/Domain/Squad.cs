using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Squad
    {
        [Key]
        public string SquadId { get; set; }
        public bool Owner { get; set; }
        public string UserProfileId { get; set; }
        public string SquadName { get; set; }
        public string Captain { get; set; }
        public string CreatedDate { get; set; }
        public string Type { get; set; }

    }
}
