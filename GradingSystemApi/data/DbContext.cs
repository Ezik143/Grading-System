using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace Team_Yeri_enrollment_system.GradingLibrary.Data
{
    public class EnrollmentDbContext : DbContext
    {
        public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options)
            : base(options)
        {
        }

        // DbSets for each model
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Subject> CourseSubjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Teacher_Subject> TeacherSubjects { get; set; }
        public DbSet<Terms> Terms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}