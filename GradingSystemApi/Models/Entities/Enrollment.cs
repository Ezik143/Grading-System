using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    // Represents a student's enrollment in a specific course and term
    public class Enrollment
    {
        // Primary key for the Enrollment entity
        [Key]
        [Required]
        public int EnrollmentID { get; set; }

        // Foreign key referencing the Student entity
        [Required]
        public required int StudentID { get; set; }

        // Navigation property for the related Student
        [ForeignKey("StudentID")]
        [Required]
        public Student? Student { get; set; }

        // Foreign key referencing the Course entity
        [Required]
        public required int CourseID { get; set; }

        // Navigation property for the related Course
        [ForeignKey("CourseID")]
        [Required]
        public Course? Course { get; set; }

        // Foreign key referencing the Term entity
        [Required]
        public required int TermID { get; set; }

        // Navigation property for the related Term
        [ForeignKey("TermID")]
        [Required]
        public Term? Term { get; set; }

        // Status of the enrollment (e.g., "Active", "Completed", "Dropped")
        [Required]
        public required string EnrollmentStatus { get; set; }
    }
}