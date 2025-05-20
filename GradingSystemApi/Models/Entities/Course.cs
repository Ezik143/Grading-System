using System.ComponentModel.DataAnnotations;

namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    // Represents a course offered in the system
    public class Course
    {
        // Primary key for the Course entity
        [Key]
        [Required]
        public int CourseID { get; set; }

        // Name of the course (e.g., "Mathematics 101")
        [Required]
        public required string CourseName { get; set; }

        // Department offering the course (e.g., "Mathematics Department")
        [Required]
        public required string Department { get; set; }

        // Total number of units
        [Required]
        public required int TotalUnits { get; set; }
    }
}