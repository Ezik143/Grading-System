using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.addDto
{
    public class SubjectDto
    {
        [Required]
        public required string SubjectCode { get; set; }
        [Required]
        public required string SubjectName { get; set; }
        [Required]
        public required int Units { get; set; }
    }
}
