using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIMS.Web.Models;

namespace SIMS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply custom configuration for IdentityUser
            modelBuilder.ApplyConfiguration(new IdentityUserConfiguration());

            // Configure table names to match existing database
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Programme>().ToTable("Programme");
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<AcademicYear>().ToTable("AcademicYear");
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<AuditTrail>().ToTable("AuditTrail");

            // Configure relationships
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Departments)
                .HasForeignKey(d => d.Faculty_id);

            modelBuilder.Entity<Programme>()
                .HasOne(p => p.Faculty)
                .WithMany(f => f.Programmes)
                .HasForeignKey(p => p.Faculty_id);

            modelBuilder.Entity<Programme>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Programmes)
                .HasForeignKey(p => p.Dept_id);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.Dept_id);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Programme)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.ProgramOfStudy);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.Student_Id);
        }
    }
}