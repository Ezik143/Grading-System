using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Classes
    {
        [Key]
        public int ClassID { get; set; }
        public required int TeacherID { get; set; }
        [ForeignKey("TeacherID")]
        public Teacher Teacher { get; set; }
        public required string Schedule { get; set; }
        public required string SubjectCode { get; set; }
        [ForeignKey("SubjectCode")]
        public Subject Subject { get; set; }
    }
}