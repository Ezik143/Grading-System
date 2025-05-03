using System.ComponentModel.DataAnnotations;

namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Course
    {
        [Key]
        [Required]
        public required int Course_ID { get; set; }
        [Required]
        public required string Course_Name { get; set; }
        [Required]
        public required string Department { get; set; }
        [Required]
        public required int Total_Units { get; set; }
    }
}