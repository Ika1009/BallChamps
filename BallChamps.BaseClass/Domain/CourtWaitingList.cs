using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallChamps.Domain
{
    public partial class CourtWaitingList
    {
        [Key]
        public string CourtWaitingListId { get; set; }
        public string CourtId { get; set; }
        public string ProfileId { get; set; }
        public DateTime SignUpTime { get; set; }
        public string Status { get; set; }
        public int Pos { get; set; }
        public string Img { get; set; }
        public string Team { get; set; }

        [NotMapped]
        public bool Selected { get; set; }

    }
}
