using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    // Represents a class entity in the grading system
    public class Class
    {
        // Primary key for the Class entity
        [Key]
        [Required]
        public int ClassID { get; set; }

        // Foreign key referencing the Teacher entity
        [Required]
        public required int TeacherID { get; set; }

        // Navigation property for the related Teacher
        [ForeignKey("TeacherID")]
        [Required]
        public Teacher? Teacher { get; set; }

        // Schedule information for the class (e.g., "Mon 9-11am")
        [Required]
        public required string Schedule { get; set; }
    }
}