using GradingSystemApi.Models.Entities;

namespace GradingSystemApi.Models.addDto
{
    public class ClassesDto
    {
        public int teacherID { get; set; }
        public required string Schedule { get; set; }
        public required string subjectCode { get; set; }
        public required Subject subject { get; set; }
    }
}
