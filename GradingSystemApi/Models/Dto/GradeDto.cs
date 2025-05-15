using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class GradeDto
    {
        [Required]
        public required int StudentID { get; set; }
        [Required]
        public required int ClassID { get; set; }
        [Required]
        public required string AssessmentType { get; set; }
        [Required]
        public required int TermID { get; set; }
        [Required]
        public required decimal Score { get; set; }
    }
}
