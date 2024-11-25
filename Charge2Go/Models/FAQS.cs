using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class FAQS
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? ImageFAQs { get; set; }
    }
}
