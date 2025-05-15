using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.addDto
{
    public class TeacherDto
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string Lastname { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
        [Required]
        public required string Department { get; set; }
    }
}
