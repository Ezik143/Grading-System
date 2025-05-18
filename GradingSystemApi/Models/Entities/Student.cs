using GradingSystemApi.Models.Entities;
using System.ComponentModel.DataAnnotations;
namespace GradingSystemApi.Models.Entities

{
    public class Student
    {
        [Key]
        [Required]
        public int StudentID { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string MiddleName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required DateOnly BirthDate { get; set; }
        [Required]
        public required char Sex { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string PhoneNumber { get; set; }
    }   
}
