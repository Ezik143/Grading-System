using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.Dto
{
    public class TermDto
    {
        [Required]
        public required string TermName { get; set; }
        [Required]
        public required DateOnly AcademicYear { get; set; }
    }
}
