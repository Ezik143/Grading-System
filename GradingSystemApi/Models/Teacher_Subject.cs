using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Teacher_Subject
    {
        [Key]
        [Required]
        public required int Teacher_Subject_ID { get; set; }
        [Required]
        public required int Teacher_ID { get; set; }
        [Required]
        public required int Subject_Code { get; set; }
    }
}