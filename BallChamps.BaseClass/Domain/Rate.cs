using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Rate
    {
        [Key]
        public string RateId { get; set; }
        public string PlayerRate { get; set; }
       
    }
}
