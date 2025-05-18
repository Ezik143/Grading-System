using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.addDto
{
    public class SubjectDto
    {
        public required string SubjectCode { get; set; }
        public required string SubjectName { get; set; }
        public required int Units { get; set; }
    }
}
