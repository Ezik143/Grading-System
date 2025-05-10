using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class CourseSubject
    {
        [Key]
        [Required]
        public int CourseSubjectID { get; set; }
        [Required]
        public required int CourseID { get; set; }
        [ForeignKey("CourseID")]
        public  Course Course { get; set; }
        [Required]
        public required string SubjectCode { get; set; }
        [ForeignKey("SubjectCode")]
        public  Subject Subject { get; set; }
    }
}