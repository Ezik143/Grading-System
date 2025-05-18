using System.ComponentModel.DataAnnotations;

namespace GradingSystemApi.Models.addDto
{
    public class TeacherDto
    {
        public required string FirstName { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Department { get; set; }
    }
}
