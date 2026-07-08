using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Index(nameof(JobCandidateId), IsUnique = true)]
    public class Resume
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int JobCandidateId { get; set; } // Ім'я класа і ID дають FOREIGN KEY (зовнішній ключ).

        public JobCandidate? JobCandidate { get; set; } // Зв'язок з таблицею JobCandidates.

        [MaxLength(50)]
        public string? MimeType { get; set; }

        public string? FileName { get; set; }

        public byte[]? Data { get; set; }
    }
}
