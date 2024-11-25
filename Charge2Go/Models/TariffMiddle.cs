using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class TariffMiddle
    {
        [Key]
        public int ID { get; set; }

        public string? TariffPriceImage { get; set; }

        [Required]
        public string? TariffPriceDescription { get; set; }

        public string? TariffScheduleImage { get; set; }

        [Required]
        public string? TariffScheduleDescription { get; set; }

        public string? TariffCampaignImage { get; set; }

        [Required]
        public string? TariffCampaignDescription { get; set; }
    }
}
