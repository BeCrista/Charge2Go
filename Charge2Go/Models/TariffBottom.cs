using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class TariffBottom
    {
        [Key]
        public int ID { get; set; }

        public string? TariffSolutionImage { get; set; }

        [Required]
        public string? TariffSolutionTitle { get; set; }

        [Required]
        public string? TariffSolutionSubtitle { get; set; }
    }
}
