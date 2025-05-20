using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities

{
    // Represents a student in the enrollment and grading system
    public class Student
    {
        // Primary key for the Student entity
        [Key]
        [Required]
        public int StudentID { get; set; }

        // Student's first name
        [Required]
        public required string FirstName { get; set; }

        // Student's middle name
        [Required]
        public required string MiddleName { get; set; }

        // Student's last name
        [Required]
        public required string LastName { get; set; }

        // Student's date of birth
        [Required]
        public required DateOnly BirthDate { get; set; }

        // Student's sex (e.g., 'M' or 'F')
        [Required]
        public required char Sex { get; set; }

        // Student's email address
        [Required]
        public required string Email { get; set; }

        // Student's phone number
        [Required]
        public required string PhoneNumber { get; set; }
    }
}
