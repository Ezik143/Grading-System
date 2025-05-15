using GradingSystemApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace Team_Yeri_enrollment_system.GradingLibrary.Data
{
    public class GradingDbContext : DbContext
    {
        public GradingDbContext(DbContextOptions<GradingDbContext> options)
            : base(options)
        {
        }

        // DbSets for each model
        public DbSet<Class> Class { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseSubject> CourseSubject { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<TeacherSubject> TeacherSubject { get; set; }
        public DbSet<Term> Term { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}