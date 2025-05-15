using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class TeacherSubjectDto
    {
        [Required]
        public required int TeacherID { get; set; }
        [Required]
        public required string SubjectCode { get; set; }
    }
}
