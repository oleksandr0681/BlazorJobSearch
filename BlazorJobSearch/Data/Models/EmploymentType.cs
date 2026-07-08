using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorJobSearch.Data.Models
{
    [Index(nameof(Name), IsUnique = true), Display(Name = "Тип зайнятості")]
    public class EmploymentType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
