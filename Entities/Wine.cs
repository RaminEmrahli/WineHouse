using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineHouse.Entities
{
    public class Wine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specifications { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [NotMapped,Required]
        public IFormFile File { get; set; }
    }
}
