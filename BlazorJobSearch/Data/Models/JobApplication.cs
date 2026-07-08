using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Display(Name = "Заявка на вакансію")]
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        public int VacancyId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Vacancy? Vacancy { get; set; } // Зв'язок з таблицею Vacancies.

        public int JobCandidateId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public JobCandidate? JobCandidate { get; set; } // Зв'язок з таблицею JobCandidates.

        [Display(Name = "Створено")]
        public DateTime Created { get; set; } = DateTime.Now;

        [Display(Name = "Переглянуто роботодавцем")]
        public DateTime? Viewed { get; set; }
    }
}
