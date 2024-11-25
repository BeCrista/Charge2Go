using System.ComponentModel.DataAnnotations;

namespace Charge2Go.Models
{
    public class FAQSQuestions
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string? QuestionFAQ { get; set; }

        [Required]
        public string? AnswerFAQ { get; set; }
    }
}
