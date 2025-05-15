using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GradingSystemApi.Models.Entities
{
    public class TeacherSubject
    {
        [Key]
        [Required]
        public int TeacherSubjectID { get; set; }
        [Required]
        public required int TeacherID { get; set; }
        [ForeignKey("TeacherID")]
        [Required]
        public  Teacher? Teacher { get; set; }

        [Required]
        public required string SubjectCode { get; set; }
        [ForeignKey("SubjectCode")]
        [Required]
        public  Subject? Subject { get; set; }
    }
}