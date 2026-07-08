using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Display(Name = "Повідомлення")]
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Від")]
        public string FromId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "До")]
        public string ToId { get; set; } = string.Empty;

        [Required]
        public int JobCandidateId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public JobCandidate? JobCandidate { get; set; } // Зв'язок з таблицею JobCandidates.

        [Required]
        public int EmployerId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Employer? Employer { get; set; } // Зв'язок з таблицею Employers.

        [Display(Name = "Заголовок")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Основна частина")]
        public string Body { get; set; } = string.Empty;

        [Display(Name = "Відправлено")]
        public DateTime Sent { get; set; } = DateTime.Now;

        [Display(Name = "Переглянуто")]
        public DateTime? Viewed { get; set; }
    }
}
