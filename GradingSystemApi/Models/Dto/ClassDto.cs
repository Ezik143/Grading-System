using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.addDto
{
    public class ClassDto
    {
        [Required]
        public required int TeacherID { get; set; }
        [Required]
        public required string Schedule { get; set; }
        [Required]
        public required string SubjectCode { get; set; }
    }
}