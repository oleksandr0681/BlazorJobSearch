using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int JobCandidateId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public JobCandidate? JobCandidate { get; set; } // Зв'язок з таблицею JobCandidates.

        [Required, MaxLength(150), Display(Name = "Назва")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000), Display(Name = "Опис")]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? MimeType { get; set; }

        public string? FileName { get; set; }

        public byte[]? Data { get; set; }
    }
}
