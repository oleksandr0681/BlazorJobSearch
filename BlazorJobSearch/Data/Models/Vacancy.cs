using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Display(Name = "Вакансія")]
    public class Vacancy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployerId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public Employer? Employer { get; set; } // Зв'язок з таблицею Employers.

        [MaxLength(100), Display(Name = "Галузь")]
        public string Sector {  get; set; } = string.Empty;

        [Required, MaxLength(100), Display(Name = "Посада")]
        public string Job { get; set; } = string.Empty;

        [Display(Name = "Заробітна плата")]
        public int? Salary { get; set; }

        [MaxLength(2000), Display(Name = "Опис роботи")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(2000), Display(Name = "Вимоги")]
        public string? Requirements { get; set; }

        [MaxLength(1000), Display(Name = "Ключові слова")]
        public string? KeyWords { get; set; }

        [Required]
        public int WorkingConditionId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public WorkingCondition? WorkingCondition { get; set; } // Зв'язок з таблицею WorkConditions.

        [MaxLength(100), Display(Name = "Населений пункт")]
        public string Settlement { get; set; } = string.Empty;

        [MaxLength(1000), Display(Name = "Адреса")]
        public string Address { get; set; } = string.Empty;

        [Required]
        public int EmploymentTypeId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public EmploymentType? EmploymentType { get; set; }  // Зв'язок з таблицею EmploymentTypes. 

        [DataType(DataType.Date)]
        public DateTime? Created { get; set; } = DateTime.Today;

        public ICollection<JobApplication>? JobApplications { get; set; }
    }
}
