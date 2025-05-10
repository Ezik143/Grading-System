using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class TeacherSubjectDto
    {
        public required int TeacherID { get; set; }
        public required string SubjectCode { get; set; }
    }
}
