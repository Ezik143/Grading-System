    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Enrollment
    {
        [Key]
        [Required]
        public int EnrollmentID { get; set; }
        [Required]
        public required int StudentID { get; set; }
        [ForeignKey("StudentID")]
        [Required]
        public Student? Student { get; set; }
        [Required]
        public required int CourseID { get; set; }
        [ForeignKey("CourseID")]
        [Required]
        public Course? Course { get; set; }
        [Required]
        public required int TermID { get; set; }
        [ForeignKey("TermID")]
        [Required]
        public Term? Term { get; set; }
        [Required]
        public required string EnrollmentStatus { get; set; }

    }
}