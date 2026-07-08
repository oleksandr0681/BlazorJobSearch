using BlazorJobSearch.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorJobSearch.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<WorkingCondition>(entity => { entity.HasKey(k => k.Id); });
            builder.Entity<WorkingCondition>().HasData(
                new WorkingCondition { Id = 1, Name = "Оптимальні умови праці" }, 
                new WorkingCondition { Id = 2, Name = "Допустимі умови праці" }, 
                new WorkingCondition { Id = 3, Name = "Шкідливі умови праці" }, 
                new WorkingCondition { Id = 4, Name = "Небезпечні умови праці" });
            builder.Entity<EmploymentType>(entity => { entity.HasKey(k => k.Id); });
            builder.Entity<EmploymentType>().HasData( 
                new EmploymentType { Id = 1, Name = "Повна зайнятість" }, 
                new EmploymentType { Id = 2, Name = "Часткова зайнятість" }, 
                new EmploymentType { Id = 3, Name = "Стажування" });
        }

        public DbSet<JobCandidate> JobCandidates { get; set; }

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<Picture> Portfolios { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<Vacancy> Vacancies { get; set; }

        public DbSet<WorkingCondition> WorkConditions { get; set; }

        public DbSet<EmploymentType> EmploymentTypes { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
