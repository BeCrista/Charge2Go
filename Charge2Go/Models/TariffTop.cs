using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class TariffTop
    {
        [Key]
        public int ID { get; set; }

        public string? ImageTop { get; set; }

        [Required]
        public string? Description { get; set; }

        public string? ImageCard { get; set; }
    }
}
