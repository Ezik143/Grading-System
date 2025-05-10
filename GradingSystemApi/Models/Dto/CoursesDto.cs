namespace GradingSystemApi.Models.Dto
{
    public class CoursesDto
    {
            public required string CourseName { get; set; }

            public required string Department { get; set; }
            public required int TotalUnits { get; set; }
    }
}
