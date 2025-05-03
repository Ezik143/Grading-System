using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Course_Subject
    {
        [Key]
        [Required]
        public required int Course_Subject_ID { get; set; }
        [Required]
        public required int Course_ID { get; set; }
        [Required]
        public required int Subject_Code { get; set; }
    }
}