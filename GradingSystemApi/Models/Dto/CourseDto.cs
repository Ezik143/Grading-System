using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class CourseDto
    {
        [Required]
        public required string CourseName { get; set; }
        [Required]
        public required string Department { get; set; }
        [Required]
        public required int TotalUnits { get; set; }
    }
}
