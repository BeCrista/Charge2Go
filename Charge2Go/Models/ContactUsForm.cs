using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class ContactUsForm
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Telefone { get; set; }
        [Required]
        public string? Mensagem { get; set; }
    }
}
