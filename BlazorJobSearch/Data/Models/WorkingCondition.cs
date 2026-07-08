using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Index(nameof(Name), IsUnique = true), Display(Name = "Умови праці")]
    public class WorkingCondition
    {
        [Key] [Required]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
