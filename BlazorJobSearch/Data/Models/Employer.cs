using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Index(nameof(ApplicationUserId), IsUnique = true), Display(Name = "Роботодавець")]
    public class Employer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string ApplicationUserId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public ApplicationUser? ApplicationUser { get; set; } // Зв'язок з таблицею AspNetUsers.

        [MaxLength(150), Display(Name = "Назва компанії")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(2000), Display(Name = "Опис")]
        public string? Description { get; set; }

        [MaxLength(2000), Display(Name = "Історія")]
        public string? History {  get; set; }

        [MaxLength(100), Display(Name = "Населений пункт")]
        public string Settlement { get; set; } = string.Empty;

        [MaxLength(1000), Display(Name = "Адреса")]
        public string Address { get; set; } = string.Empty;

        [MaxLength(20), DataType(DataType.PhoneNumber), Display(Name = "Телефон")]
        public string TelephoneNumber { get; set; } = string.Empty;

        [MaxLength(200), DataType(DataType.EmailAddress), Display(Name = "Електронна пошта")]
        public string? Email { get; set; } = string.Empty;

        public ICollection<Vacancy>? Vacancies { get; set; }
    }
}
