using GradingSystemApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Team_Yeri_enrollment_system.GradingLibrary.Models;

namespace Team_Yeri_enrollment_system.GradingLibrary.Data
{
    // The database context for the grading system application.
    // This class manages the entity models and database connections using Entity Framework Core.
    public class GradingDbContext : DbContext
    {
        // Constructor that accepts options for configuring the context (e.g., connection string).
        public GradingDbContext(DbContextOptions<GradingDbContext> options)
            : base(options)
        {
        }

        // DbSet properties represent tables in the database for each entity.
        public DbSet<Class> Class { get; set; }                   // Table for classes
        public DbSet<Course> Course { get; set; }                 // Table for courses
        public DbSet<CourseSubject> CourseSubject { get; set; }   // Table for course-subject relationships
        public DbSet<Enrollment> Enrollment { get; set; }         // Table for enrollments
        public DbSet<Grade> Grade { get; set; }                   // Table for grades
        public DbSet<Student> Student { get; set; }               // Table for students
        public DbSet<Subject> Subject { get; set; }               // Table for subjects
        public DbSet<Teacher> Teacher { get; set; }               // Table for teachers
        public DbSet<TeacherSubject> TeacherSubject { get; set; } // Table for teacher-subject relationships
        public DbSet<Term> Term { get; set; }                     // Table for academic terms
        public DbSet<GradingPeriod> GradingPeriod { get; set; }   // Table for grading periods

        // Configures the model and relationships between entities.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}