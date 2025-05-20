using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    // Represents a grade record for a student's enrollment in a class and grading period
    public class Grade
    {
        // Primary key for the Grade entity
        [Key]
        [Required]
        public int GradeID { get; set; }

        // The education level for which the grade is recorded (e.g., "Undergraduate", "High School")
        [Required]
        public required string EducationLevel { get; set; }

        // The ID of the class associated with this grade
        public required int ClassID { get; set; }

        // The actual grade value (e.g., 95.50)
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public required decimal GradeValue { get; set; }

        // The equivalent value of the grade (e.g., 1.25 for 95.50)
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public required decimal GradeEquivalent { get; set; }

        // Remarks or comments about the grade (e.g., "Passed", "Incomplete")
        [Required]
        public required string Remark { get; set; }

        // Foreign key referencing the GradingPeriod entity
        [Required]
        public required int GradingPeriodID { get; set; }

        // Navigation property for the related GradingPeriod
        [ForeignKey("GradingPeriodID")]
        [Required]
        public GradingPeriod? GradingPeriod { get; set; }

        // The enrollment record associated with this grade
        [Required]
        public required int EnrollmentID { get; set; }

        // The date when the grade was recorded
        [Required]
        public required DateOnly DateRecorded { get; set; }
    }
}