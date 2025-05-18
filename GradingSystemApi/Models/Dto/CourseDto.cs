using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class CourseDto
    {
        public required string CourseName { get; set; }
        public required string Department { get; set; }
        public required int TotalUnits { get; set; }
    }
}
