using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Team_Yeri_enrollment_system.GradingLibrary.Models
{
    public class Course
    {
        //Hi
        [Key]
        public required int courseID { get; set; }
        [Required]
        [MaxLength(100)]
        public required string courseName { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Department { get; set; }
        [Required]
        [MaxLength(500)]
        public required int totalUnits { get; set; }
        public List<courseSubject> CourseSubjects { get; set; } 
    }
}