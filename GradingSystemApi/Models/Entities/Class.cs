using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Class
    {
        [Key]
        [Required]
        public int ClassID { get; set; }
        [Required]
        public required int TeacherID { get; set; }
        [ForeignKey("TeacherID")]
        [Required]
        public Teacher? Teacher { get; set; }

        [Required]
        public required string Schedule { get; set; }
        [Required]
        public required string SubjectCode { get; set; }
        [ForeignKey("SubjectCode")]
        [Required]
        public Subject? Subject { get; set; }
    }
}