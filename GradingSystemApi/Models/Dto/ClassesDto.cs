using GradingSystemApi.Models.Entities;

namespace GradingSystemApi.Models.addDto
{
    public class ClassesDto
    {
        public required int TeacherID { get; set; }
        public required string Schedule { get; set; }
        public required string SubjectCode { get; set; }
    }
}