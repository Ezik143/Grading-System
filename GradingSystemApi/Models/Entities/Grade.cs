using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team_Yeri_enrollment_system.GradingLibrary.Models;
namespace GradingSystemApi.Models.Entities
{
    public class Grade
    {
        [Key]
        [Required]
        public int GradeID { get; set; }
        [Required]
        public required string EducationLevel { get; set; }
        public  required int ClassID { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public required decimal GradeValue { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public required decimal GradeEquivalent { get; set; }
        [Required]
        public required string Remark { get; set; }
        [Required]
        public required int GradingPeriodID { get; set; }
        [ForeignKey("GradingPeriodID")]
        [Required]
        public GradingPeriod? GradingPeriod { get; set; }
        [Required]
        public  required int EnrollmentID { get; set; }
        [Required]
        public required DateOnly DateRecorded { get; set; }
    }
}