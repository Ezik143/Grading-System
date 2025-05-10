using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Grades
    {
        [Key]
        [Required]
        public int GradeID { get; set; }
        [Required]
        [ForeignKey("StudentID")]
        public required int StudentID { get; set; }
        [Required]
        [ForeignKey("ClassID")]
        public required int ClassID { get; set; }
        [Required]
        public required string AssessmentType { get; set; }
        [Required]
        [ForeignKey("TermID")]
        public required int TermID { get; set; }
        [Required]
        [ForeignKey("SubjectCode")]
        public required string SubjectCode { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Score { get; set; }
    }
}