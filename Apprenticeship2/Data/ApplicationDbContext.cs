using Apprenticeship2.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Apprenticeship2.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public DbSet<Student> students { get; set; }
        public DbSet<TeamLeader> teamLeaders { get; set; }
        public DbSet<UniversitySupervisor> universitySupervisors { get; set; }
        public DbSet<Company> companys { get; set; }
        public DbSet<University> universities { get; set; }
        public DbSet<Objective> objectives { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<ObjectivesSkills> objectivesSkills { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<AssignmentObjectives> assignmentObjectives { get; set; }
        public DbSet<Training> trainings { get; set; }
        public DbSet<TrainingObjectives> trainingObjectives { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportStatus> ReportStatus { get; set; }
        public DbSet<ReportLog> reportLogs { get; set; }
        public DbSet<AssignmentFiles> assignmentFiles { get; set; }
        public DbSet<ReportFiles> reportFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ReportLog>()
               .HasOne(x => x.reportStatus)
               .WithOne(x => x.reportLog)
               .HasForeignKey<ReportLog>(x => x.reportStatusId);
            
            modelBuilder.Entity<Training>().HasKey(T => T.TrainingId);
            modelBuilder.Entity<ObjectivesSkills>().HasKey(os => new { os.skillId, os.objectiveId });

            modelBuilder.Entity<TrainingObjectives>().HasKey(TO => new { TO.objectiveId, TO.trainingId });
            modelBuilder.Entity<AssignmentObjectives>().HasKey(AO => new { AO.objectiveId, AO.assignmentId });
           
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}