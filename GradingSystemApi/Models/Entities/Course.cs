using System.ComponentModel.DataAnnotations;

namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int CourseID { get; set; }
        [Required]
        public required string CourseName { get; set; }
        [Required]
        public required string Department { get; set; }
        [Required]
        public required int TotalUnits { get; set; }
    }
}