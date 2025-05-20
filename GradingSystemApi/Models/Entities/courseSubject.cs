using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    // Represents the association between a Course and a Subject
    public class CourseSubject
    {
        // Primary key for the CourseSubject entity
        [Key]
        [Required]
        public int CourseSubjectID { get; set; }

        // Foreign key referencing the Course entity
        [Required]
        public required int CourseID { get; set; }

        // Navigation property for the related Course
        [ForeignKey("CourseID")]
        [Required]
        public Course? Course { get; set; }

        // Foreign key referencing the Subject entity by its code
        [Required]
        public required string SubjectCode { get; set; }

        // Navigation property for the related Subject
        [ForeignKey("SubjectCode")]
        [Required]
        public Subject? Subject { get; set; }
    }
}