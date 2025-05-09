namespace GradingSystemApi.Models.Dto
{
    public class CoursesDto
    {
            public required string courseName { get; set; }

            public required string Department { get; set; }

            public required int totalUnits { get; set; }
    }
}
