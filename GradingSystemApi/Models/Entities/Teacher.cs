using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities
{
    // Represents a teacher in the academic system
    public class Teacher
    {
        // Primary key for the Teacher entity
        [Key]
        [Required]
        public int TeacherID { get; set; }

        // Teacher's first name
        [Required]
        public required string FirstName { get; set; }

        // Teacher's last name
        [Required]
        public required string Lastname { get; set; }

        // Teacher's email address
        [Required]
        public required string Email { get; set; }

        // Teacher's phone number
        [Required]
        public required string PhoneNumber { get; set; }

        // Department to which the teacher belongs
        [Required]
        public required string Department { get; set; }
    }
}