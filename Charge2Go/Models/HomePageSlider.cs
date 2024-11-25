using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class HomePageSlider
    {
        [Key]
        public int ID { get; set; }

        public string? ImageSlider { get; set; }

        [Required]
        public string? TitleSlider { get; set; }

        [Required]
        public string? SubTitleSlider { get; set;}
    }
}
