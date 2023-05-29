using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Messages
    {
        [Key]
        public string MessageId { get; set; }
        public string Message { get; set; }
        public string CreatedDate { get; set; }
        public string Descritpion { get; set; }
        public string SendTo { get; set; }
        public string Type { get; set; }
        public string FromEmail { get; set; }
    }
}
