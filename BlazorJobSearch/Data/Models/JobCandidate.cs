using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Index(nameof(ApplicationUserId), IsUnique = true), Display(Name = "Кандидат на роботу")]
    public class JobCandidate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string ApplicationUserId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public ApplicationUser? ApplicationUser { get; set; } // Зв'язок з таблицею AspNetUsers.

        [Required (ErrorMessage = "Потрібно ввести ПІБ."), MaxLength(200), 
            Display(Name = "Прізвище, ім'я, по батькові")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Дата народження"), DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [MaxLength(100), Display(Name = "Місце проживання")]
        public string? Residence { get; set; }

        [Required(ErrorMessage = "Потрібно ввести телефон."), MaxLength(20), 
            DataType(DataType.PhoneNumber), Display(Name = "Телефон")]
        public string TelephoneNumber { get; set; } = string.Empty;

        [MaxLength(200), DataType(DataType.EmailAddress), Display(Name = "Електронна пошта")]
        public string? Email { get; set; } = string.Empty;

        [MaxLength(100), Display(Name = "Галузь")]
        public string? Sector { get; set; }

        [Required(ErrorMessage = "Потрібно ввести посаду."), MaxLength(100), 
            Display(Name = "Посада")]
        public string Job { get; set; } = string.Empty;

        [MaxLength(10000), Display(Name = "Досвід роботи")]
        public string? WorkExperience { get; set; }

        [MaxLength(2000), Display(Name = "Навички")]
        public string? Skills { get; set; }

        [Display(Name = "Портфоліо")]
        public ICollection<Picture>? Portfolio {  get; set; }
    }
}
