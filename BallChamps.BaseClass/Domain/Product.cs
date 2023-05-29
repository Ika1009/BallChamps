using System.ComponentModel.DataAnnotations;

namespace BallChamps.Domain
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
        public string Images { get; set; }
        public string ImagePath { get; set; }
        public string ProductNumber { get; set; }
        public string Category { get; set; }
        public int Points { get; set; }
        public string Status { get; set; }
        public string ObjType { get; set; }
    }
}
