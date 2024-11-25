using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class RedeChargingPoint
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? NormalChargingPointTitle { get; set; }

        [Required]
        public string? NormalChargingPointDescription { get; set; }

        [Required]
        public string? QuickChargingPointTitle { get; set; }

        [Required]
        public string? QuickChargingPointDescription { get; set; }
    }
}
