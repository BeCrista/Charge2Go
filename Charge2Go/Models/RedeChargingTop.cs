using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class RedeChargingTop
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Subtitle { get; set; }

        public string? ImageTop { get; set; }
    }
}
