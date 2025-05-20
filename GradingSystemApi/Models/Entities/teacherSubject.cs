using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GradingSystemApi.Models.Entities
{
    // Represents the association between a teacher and a subject they teach
    public class TeacherSubject
    {
        // Primary key for the TeacherSubject entity
        [Key]
        [Required]
        public int TeacherSubjectID { get; set; }

        // Foreign key referencing the Teacher entity
        [Required]
        public required int TeacherID { get; set; }

        // Navigation property for the related Teacher
        [ForeignKey("TeacherID")]
        [Required]
        public Teacher? Teacher { get; set; }

        // Foreign key referencing the Subject entity by its code
        [Required]
        public required string SubjectCode { get; set; }

        // Navigation property for the related Subject
        [ForeignKey("SubjectCode")]
        [Required]
        public Subject? Subject { get; set; }
    }
}