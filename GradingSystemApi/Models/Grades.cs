using System.ComponentModel.DataAnnotations;
namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Grades
    {
        [Key]
        [Required]
        public required int Grade_ID { get; set; }
        [Required]
        public required int Student_ID { get; set; }
        [Required]
        public required int Class_ID { get; set; }
        [Required]
        public required string Assessment_type { get; set; }
        [Required]
        public required int Term_ID { get; set; }
        [Required]
        public required string Subject_Code { get; set; }
        public  decimal Score { get; set; }
    }
}