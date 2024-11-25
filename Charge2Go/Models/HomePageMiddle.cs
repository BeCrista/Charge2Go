using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class HomePageMiddle
    {
        [Key]
        public int ID { get; set; }
        public string? ImageMiddle { get; set; }

        [Required] 
        public string? ImageMiddleTitle { get; set;}

        [Required]
        public string? ImageMiddleSubtitle { get; set;}
    }
}
